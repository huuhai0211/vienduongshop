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
    [RoutePrefix("api/contributor")]
    [Authorize]
    public class ContributorController : ApiControllerBase 
    {
        private IContributorService _contributorService;

        public ContributorController(IErrorService errorService, IContributorService contributorService) : base(errorService)
        {
            this._contributorService = contributorService;
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _contributorService.GetById(id);
                var responseData = Mapper.Map<Contributor, ContributorViewModel>(model);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _contributorService.GetAll(keyword);
                int totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
                var responseData = Mapper.Map<IEnumerable<Contributor>, IEnumerable<ContributorViewModel>>(query);
                var paginationSet = new PaginationSet<ContributorViewModel>()
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
        public HttpResponseMessage Create(HttpRequestMessage request, ContributorViewModel contributorViewModel)
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
                    var newContributor = new Contributor();
                    newContributor.UpdateContributor(contributorViewModel);
                    newContributor.CreatedDate = DateTime.Now;
                    newContributor.CreatedBy = User.Identity.Name;
                   _contributorService.Add(newContributor);
                    _contributorService.Save();

                    var responseData = Mapper.Map<Contributor, ContributorViewModel>(newContributor);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, ContributorViewModel contributorViewModel)
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
                    var dbContributor = _contributorService.GetById(contributorViewModel.ID_Business);
                    dbContributor.UpdateContributor(contributorViewModel);
                    dbContributor.UpdatedDate = DateTime.Now;
                    dbContributor.UpdatedBy = User.Identity.Name;
                    _contributorService.Update(dbContributor);
                   _contributorService.Save();

                    var responseData = Mapper.Map<Contributor, ContributorViewModel>(dbContributor);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);

                }

                return response;
            });
        }

        //[Route("delete")]
        //[HttpDelete]
        //public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (!ModelState.IsValid)
        //        {
        //            response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            var oldContributor =_contributorService.Delete(id);
        //            _contributorService.Save();

        //            var responseData = Mapper.Map<Contributor, ContributorViewModel>(oldContributor);
        //            response = request.CreateResponse(HttpStatusCode.Created, responseData);

        //        }

        //        return response;
        //    });
        //}

        //[Route("deletemulti")]
        //[HttpDelete]
        //public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedProductCategories)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (!ModelState.IsValid)
        //        {
        //            response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            var listProductCategories = new JavaScriptSerializer().Deserialize<List<int>>(checkedProductCategories);

        //            foreach (var item in listProductCategories)
        //            {
        //                _contributorService.Delete(item);
        //            }
        //            _contributorService.Save();
        //            response = request.CreateResponse(HttpStatusCode.Created, true);

        //        }

        //        return response;
        //    });
        //}

    }
}
