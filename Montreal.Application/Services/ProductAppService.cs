using AutoMapper;
using AutoMapper.QueryableExtensions;
using Montreal.Application.Interfaces;
using Montreal.Application.ViewModels;
using Montreal.Domain.Commands;
using Montreal.Domain.Core.Bus;
using Montreal.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Montreal.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IMediatorHandler Bus;

        public ProductAppService(IMapper mapper,
                                  IProductRepository productRepository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            Bus = bus;
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(_productRepository.GetAll());
        }

        public IEnumerable<ProductViewModel> GetAllIncludingImages()
        {
            return _productRepository.GetAllIncludingImages().ProjectTo<ProductViewModel>();
        }

        public ProductViewModel GetById(Guid id)
        {
            return _mapper.Map<ProductViewModel>(_productRepository.GetById(id));
        }

        public ProductViewModel GetByIdIncludingImages(Guid id)
        {
            return _mapper.Map<ProductViewModel>(_productRepository.GetByIdIncludingImages(id));
        }

        public void Register(ProductViewModel productViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewProductCommand>(productViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(ProductViewModel productViewModel)
        {
            var updateCommand = _mapper.Map<UpdateProductCommand>(productViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveProductCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
