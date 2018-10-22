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
    [RoutePrefix("api/client")]
    public class ClientController : ApiControllerBase
    {

        private IClientService _clientService;

        public ClientController(IErrorService errorService, IClientService clientService) : base(errorService)
        {
            this._clientService = clientService;
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _clientService.GetById(id);
                var responseData = Mapper.Map<Client, ClientViewModel>(model);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 1)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _clientService.GetAll(keyword);
                int totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
                var responseData = Mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(query);
                var paginationSet = new PaginationSet<ClientViewModel>()
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
        public HttpResponseMessage Create(HttpRequestMessage request, ClientViewModel clientViewModel)
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
                    var newClient = new Client();
                    newClient.UpdateClient(clientViewModel);
                    newClient.CreatedDate = DateTime.Now;
                    newClient.CreatedBy = User.Identity.Name;
                    _clientService.Add(newClient);
                    _clientService.Save();

                    var responseData = Mapper.Map<Client, ClientViewModel>(newClient);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, ClientViewModel clientViewModel)
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
                    var dbClient = _clientService.GetById(clientViewModel.ID);
                    dbClient.UpdateClient(clientViewModel);
                    dbClient.UpdatedDate = DateTime.Now;
                    dbClient.UpdatedBy = User.Identity.Name;
                    _clientService.Update(dbClient);
                    _clientService.Save();

                    var responseData = Mapper.Map<Client, ClientViewModel>(dbClient);
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
                    var oldClient = _clientService.Delete(id);
                    _clientService.Save();

                    var responseData = Mapper.Map<Client, ClientViewModel>(oldClient);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);

                }

                return response;
            });
        }

        [Route("deletemulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedClient)
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
                    var listClient = new JavaScriptSerializer().Deserialize<List<int>>(checkedClient);

                    foreach (var item in listClient)
                    {
                        _clientService.Delete(item);
                    }
                    _clientService.Save();
                    response = request.CreateResponse(HttpStatusCode.Created, true);

                }

                return response;
            });
        }

    }
}