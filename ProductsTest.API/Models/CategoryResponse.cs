namespace ProductsTest.API.Models
{
    using System.Collections.Generic;

    public class CategoryResponse
    {
        
        public int CategoryId { get; set; }
      
        public string Description { get; set; }

        //el objeto categoria que llamamos del api no devuelve el objeto productos por esta anotacion, 
        //sin embargo debemos dejarla por los problemas que trae esta a nivel de base de datos, ademas de que el api no sabe deserializar un objeto virtual
        //para estos fines entonces debemos crear una clase response que tiene los mismos atributos que esta clase, pero sin las anotaciones
        //en donde la propiedad virtual la debemos cambiar por una lista
        
        public List<ProductResponse> Products { get; set; }

    }
}