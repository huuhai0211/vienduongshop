using AutoMapper;
using Shop.Model.Models;
using Shop.Service;
using Shop.Web.Infrastructure.Core;
using Shop.Web.Infrastructure.Extensions;
using Shop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace Shop.Web.Api
{
    [RoutePrefix("api/importProduct")]
    [Authorize]
    public class ImportController : ApiControllerBase
    {
        private IImportService _importService;
        private IImportDetailService _importDetailService;

        public ImportController(IErrorService errorService, IImportService importService, IImportDetailService importDetailService) : base(errorService)
        {
            this._importService = importService;
            this._importDetailService = importDetailService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _importService.GetAll(keyword);
                int totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
                var responseData = Mapper.Map<IEnumerable<Import>, IEnumerable<ImportViewModel>>(query);
                var paginationSet = new PaginationSet<ImportViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, paginationSet);

                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ImportViewModel importViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newImport = new Import();
                    newImport.UpdateImport(importViewModel);
                    newImport.CreatedDate = DateTime.Now;
                    newImport.CreatedBy = User.Identity.Name;
                    _importService.Add(newImport);
                    _importService.Save();
                    //if(importDetailViewModels != null)
                    //{
                    //    var newImportDetail = new ImportDetail();
                    //    var listImportDetailViewModels = new JavaScriptSerializer().Deserialize<List<ImportDetailViewModel>>(importDetailViewModels);
                    //    foreach (var importDetailViewModel in listImportDetailViewModels)
                    //    {
                    //        newImportDetail.UpdateImportDetail(importDetailViewModel);
                    //        newImportDetail.ImportID = newImport.ID;
                    //        _importDetailService.Add(newImportDetail);
                    //        _importDetailService.Save();
                    //    }
                    //}

                    var responseData = Mapper.Map<Import, ImportViewModel>(newImport);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("createdetail")]
        [HttpGet]
        public HttpResponseMessage CreateDetail(HttpRequestMessage request, string importDetailViewModels)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    if (importDetailViewModels != null)
                    {
                        var newImportDetail = new ImportDetail();
                        var listImportDetailViewModels = new JavaScriptSerializer().Deserialize<List<ImportDetailViewModel>>(importDetailViewModels);
                        foreach (var importDetailViewModel in listImportDetailViewModels)
                        {
                            newImportDetail.UpdateImportDetail(importDetailViewModel);
                            
                            _importDetailService.Add(newImportDetail);
                            _importDetailService.Save();
                        }
                    }

                    //var responseData = Mapper.Map<Import, ImportViewModel>(newImport);
                    response = request.CreateResponse(HttpStatusCode.Created);
                }

                return response;
            });
        }
    }
}
