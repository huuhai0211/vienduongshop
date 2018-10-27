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
    [RoutePrefix("api/location")]
    [Authorize]
    public class LocationController : ApiControllerBase
    {
        private ILocationService _locationService;

        public LocationController(IErrorService errorService, ILocationService locationService) : base(errorService)
        {
            this._locationService = locationService;
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _locationService.GetById(id);
                var responseData = Mapper.Map<Location, LocationViewModel>(model);

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
                var model =_locationService.GetAll(keyword);
                int totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
                var responseData = Mapper.Map<IEnumerable<Location>, IEnumerable<LocationViewModel>>(query);
                var paginationSet = new PaginationSet<LocationViewModel>()
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
                var model = _locationService.GetAll();

                var responseData = Mapper.Map<IEnumerable<Location>, IEnumerable<LocationViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }


        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, LocationViewModel locationViewModel)
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
                    var newLocation = new Location();
                    newLocation.UpdateLocation(locationViewModel);
                    newLocation.CreatedDate = DateTime.Now;
                    newLocation.CreatedBy = User.Identity.Name;
                    _locationService.Add(newLocation);
                    _locationService.Save();

                    var responseData = Mapper.Map<Location, LocationViewModel>(newLocation);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, LocationViewModel locationViewModel)
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
                    var dbLocation =_locationService.GetById(locationViewModel.ID);
                    dbLocation.UpdateLocation(locationViewModel);
                    dbLocation.UpdatedDate = DateTime.Now;
                    dbLocation.UpdatedBy = User.Identity.Name;
                    _locationService.Update(dbLocation);
                    _locationService.Save();

                    var responseData = Mapper.Map<Location, LocationViewModel>(dbLocation);
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
                    var dbLocation = _locationService.GetById(id);
                    dbLocation.Status = false;
                    _locationService.Update(dbLocation);
                    _locationService.Save();
                    //var oldWarehouse =_warehouseService.Delete(id);
                    //_warehouseService.Save();

                    var responseData = Mapper.Map<Location, LocationViewModel>(dbLocation);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);

                }

                return response;
            });
        }

        [Route("deletemulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedLocation)
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
                    var listLocation = new JavaScriptSerializer().Deserialize<List<int>>(checkedLocation);

                    foreach (var item in listLocation)
                    {
                        _locationService.Delete(item);
                    }
                    _locationService.Save();
                    response = request.CreateResponse(HttpStatusCode.Created, true);

                }

                return response;
            });
        }
    }
}

