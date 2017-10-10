using System;
using System.Net;
using System.Web.Http;
using Microsoft.Practices.Unity;
using System.Net.Http;
using Product.Repository.Interfaces;
using Product.Repository.SQL;
using Product.Entities;
using Product.Service.Implementation;
using Product.Service.Interfaces;
using Product.Service.Interfaces.Requests;

namespace refactor_me.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        private readonly IUnityContainer _container;
        private readonly IProductService _service;

        public ProductsController()
        {
            _container = new UnityContainer();

            //tell unity container how to use IProductsRepository
            _container.RegisterType<IProductRepository, SQLProductRepository>(new ContainerControlledLifetimeManager());
            _service = _container.Resolve<ProductService>();
        }

        [Route]
        [HttpGet]
        public IHttpActionResult GetAllProducts()
        {
            var response = _service.GetAllProducts();
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, response));
        }

        [Route]
        [HttpGet]
        public IHttpActionResult GetProductByName(string name)
        {
            var response = _service.GetProductByName(new GetProductByNameRequest { Name = name.Replace("\"", "") });
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, response));
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetProductById(Guid id)
        {
            var response = _service.GetProductById(new GetProductByIdRequest { Id = id });
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, response));
        }

        [Route]
        [HttpPost]
        public IHttpActionResult AddProduct(ProductEntity product)
        {
            var response = _service.AddProduct(new AddProductRequest { ProductEntity = product });
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, response));
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult UpdateProduct(ProductEntity product)
        {
            var response = _service.UpdateProduct(new UpdateProductRequest { ProductEntity = product });
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, response));
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteProduct(Guid id)
        {
            var response = _service.DeleteProduct(new DeleteProductRequest { Id = id });
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, response));
        }

        [Route("{productId}/options")]
        [HttpGet]
        public IHttpActionResult GetProductOptions(Guid productId)
        {
            var response = _service.GetProductOptions(new GetProductOptionsRequest { ProductId = productId });
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, response));
        }

        [Route("{productId}/options/{id}")]
        [HttpGet]
        public IHttpActionResult GetProductOption(Guid productId, Guid id)
        {
            var response = _service.GetProductOption(new GetProductOptionRequest { ProductId = productId, Id = id });
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, response));
        }

        [Route("{productId}/options")]
        [HttpPost]
        public IHttpActionResult AddProductOption(ProductOptionEntity option)
        {
            var response = _service.AddProductOption(new AddProductOptionRequest { ProductOptionEntity = option });
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, response));
        }

        [Route("{productId}/options/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateProductOption(ProductOptionEntity option)
        {
            var response = _service.UpdateProductOption(new UpdateProductOptionRequest { ProductOptionEntity = option });
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, response));
        }

        [Route("{productId}/options/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteProductOption(Guid id)
        {
            var response = _service.DeleteProductOption(new DeleteProductOptionRequest { Id = id });
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, response));
        }
    }
}
