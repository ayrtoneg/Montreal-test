using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Montreal.Application.Interfaces;
using Montreal.Application.ViewModels;
using Montreal.Domain.Core.Bus;
using Montreal.Domain.Core.Notifications;
using System;

namespace Montreal.WebApi.Controllers
{
    public class ProductController : ApiController
    {

        private readonly IProductAppService _productAppService;

        public ProductController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            IProductAppService productAppService
            ) : base(notifications, mediator)
        {
            _productAppService = productAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("product/{hasInclude:bool}")]
        public IActionResult Get(bool hasInclude)
        {
            if (hasInclude)
                return Response(_productAppService.GetAllIncludingImages());

            return Response(_productAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("product/{id:guid}/{hasInclude:bool}")]
        public IActionResult Get(Guid id, bool hasInclude)
        {
            ProductViewModel productViewModel;
            if (hasInclude)
                productViewModel = _productAppService.GetByIdIncludingImages(id);
            else
                productViewModel = _productAppService.GetById(id);

            return Response(productViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("product")]
        public IActionResult Post([FromBody]ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(productViewModel);
            }

            _productAppService.Register(productViewModel);

            return Response();
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("product")]
        public IActionResult Put([FromBody]ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(productViewModel);
            }

            _productAppService.Update(productViewModel);

            return Response();
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("product/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _productAppService.Remove(id);

            return Response();
        }
    }
}