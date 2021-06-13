using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.App.DTOs;
using BookStore.Business.Interfaces;
using AutoMapper;
using BookStore.MVC.Models;

namespace BookStore.App.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository, IProviderRepository providerRepository, IMapper mapper)
        {
            this._productRepository = productRepository;
            this._providerRepository = providerRepository;
            this._mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProductDTO>>(await _productRepository.GetProductsProviders()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var productDTO = await GetProductById(id);

            if (productDTO == null)
            {
                return NotFound();
            }

            return View(productDTO);
        }


        public async Task<IActionResult> Create()
        {
            var productDTO = await PopulateProviders(new ProductDTO());
            return View(productDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {
            productDTO = await PopulateProviders(productDTO);

            if (!ModelState.IsValid) return View(productDTO);

            await _productRepository.Add(_mapper.Map<Product>(productDTO));

            return View(productDTO);
        }


        public async Task<IActionResult> Edit(Guid id)
        {
            var productDTO = await GetProductById(id);

            if (productDTO == null)
            {
                return NotFound();
            }

            return View(productDTO);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProductDTO productDTO)
        {
            if (id != productDTO.Id) return NotFound();

            if (!ModelState.IsValid) return View(productDTO);

            await _productRepository.Update(_mapper.Map<Product>(productDTO));
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await GetProductById(id);

            if (product == null) return NotFound();

            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = await GetProductById(id);

            if (product == null) return NotFound();

            await _productRepository.Remove(id);

            return RedirectToAction("Index");
        }

        private async Task<ProductDTO> GetProductById(Guid id)
        {
            var product = _mapper.Map<ProductDTO>(await _productRepository.GetProductProvider(id));
            product.Providers = _mapper.Map<IEnumerable<ProviderDTO>>(await _providerRepository.GetAll());

            return product;
        }

        private async Task<ProductDTO> PopulateProviders(ProductDTO product)
        {
            product.Providers = _mapper.Map<IEnumerable<ProviderDTO>>(await _providerRepository.GetAll());

            return product;
        }
    }
}
