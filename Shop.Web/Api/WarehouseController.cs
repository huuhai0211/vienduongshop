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
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace Shop.Web.Api
{
    [RoutePrefix("api/warehouse")]
    [Authorize]
    public class WarehouseController : ApiControllerBase
    {
        private IWarehouseService _warehouseService;

        public WarehouseController(IErrorService errorService, IWarehouseService warehouseService) : base(errorService)
        {
            this._warehouseService = warehouseService;
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _warehouseService.GetById(id);
                var responseData = Mapper.Map<Warehouse, WarehouseViewModel>(model);

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
                var model = _warehouseService.GetAll(keyword);
                int totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
                var responseData = Mapper.Map<IEnumerable<Warehouse>, IEnumerable<WarehouseViewModel>>(query);
                var paginationSet = new PaginationSet<WarehouseViewModel>()
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

        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _warehouseService.GetAll();
                var responseData = Mapper.Map<IEnumerable<Warehouse>, IEnumerable<WarehouseViewModel>>(model);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, WarehouseViewModel productCategoryViewModel)
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
                    var newWarehouse = new Warehouse();
                    newWarehouse.UpdateWarehouse(productCategoryViewModel);
                    newWarehouse.CreatedDate = DateTime.Now;
                    _warehouseService.Add(newWarehouse);
                    _warehouseService.Save();

                    var responseData = Mapper.Map<Warehouse, WarehouseViewModel>(newWarehouse);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);

                }

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, WarehouseViewModel productCategoryViewModel)
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
                    var dbWarehouse = _warehouseService.GetById(productCategoryViewModel.ID);
                    dbWarehouse.UpdateWarehouse(productCategoryViewModel);
                    dbWarehouse.UpdatedDate = DateTime.Now;
                    _warehouseService.Update(dbWarehouse);
                    _warehouseService.Save();

                    var responseData = Mapper.Map<Warehouse, WarehouseViewModel>(dbWarehouse);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);

                }

                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
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
                    var dbWarehouse = _warehouseService.GetById(id);
                    dbWarehouse.Status = false;
                    _warehouseService.Update(dbWarehouse);
                    _warehouseService.Save();
                    //var oldWarehouse =_warehouseService.Delete(id);
                    //_warehouseService.Save();

                    var responseData = Mapper.Map<Warehouse, WarehouseViewModel>(dbWarehouse);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);

                }

                return response;
            });
        }

        [Route("deletemulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedProductCategories)
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
                    var listProductCategories = new JavaScriptSerializer().Deserialize<List<int>>(checkedProductCategories);

                    foreach (var item in listProductCategories)
                    {
                        _warehouseService.Delete(item);
                    }
                    _warehouseService.Save();
                    response = request.CreateResponse(HttpStatusCode.Created, true);

                }

                return response;
            });
        }
    }
}