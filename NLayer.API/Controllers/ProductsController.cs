﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController {

        private readonly IMapper _mapper;
        private readonly IService<Product> _service;

        public ProductsController(IService<Product> service, IMapper mapper) {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All() {
            var products = await _service.GetAllAsync();
            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var products = await _service.GetByIdAsync(id);
            var productsDtos = _mapper.Map<ProductDto>(products);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDtos));
        }

        [HttpPost()]
        public async Task<IActionResult> Save(ProductDto productDto) {
            var products = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDtos = _mapper.Map<ProductDto>(products);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDtos));
        }

        [HttpPut()]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto) {
            await _service.UpdateAsync(_mapper.Map<Product>(productUpdateDto));         
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
            //geriye bir şey dönmeye gerek olmadığından dolayı özel yazılan noContentDto döndük 204 durum kodunu verdik.
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id) {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
