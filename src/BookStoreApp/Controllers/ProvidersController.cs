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

    public class ProvidersController : BaseController
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IMapper _mapper;

        public ProvidersController(IProviderRepository providerRepository, IMapper mapper)
        {
            this._providerRepository = providerRepository;
            this._mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProviderDTO>>(await _providerRepository.GetAll()));
        }


        public async Task<IActionResult> Details(Guid id)
        {
            var providerDTO = await GetProviderAddress(id);

            if (providerDTO == null)
            {
                return NotFound();
            }

            return View(providerDTO);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProviderDTO providerDTO)
        {
            if (!ModelState.IsValid) return View(providerDTO);

            var provider = _mapper.Map<Provider>(providerDTO);
            await _providerRepository.Add(provider);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var providerDTO = await GetProviderProductsAddress(id);

            if (providerDTO == null)
            {
                return NotFound();
            }

            return View(providerDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProviderDTO providerDTO)
        {
            if (id != providerDTO.Id) return NotFound();

            if (!ModelState.IsValid) return View(providerDTO);

            var provider = _mapper.Map<Provider>(providerDTO);
            await _providerRepository.Update(provider);

            return RedirectToAction("Index");  
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var providerDTO = await GetProviderAddress(id);

            if (providerDTO == null)
            {
                return NotFound();
            }

            return View(providerDTO);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var providerDTO = await GetProviderAddress(id);

            if (providerDTO == null) return NotFound();

            await _providerRepository.Remove(id);

            return RedirectToAction("Index");
        }


        private async Task<ProviderDTO> GetProviderAddress(Guid id)
        {
            return _mapper.Map<ProviderDTO>(await _providerRepository.GetProviderAddress(id));
        }

        private async Task<ProviderDTO> GetProviderProductsAddress(Guid id)
        {
            return _mapper.Map<ProviderDTO>(await _providerRepository.GetProviderProductcAddress(id));
        }
    }
}
