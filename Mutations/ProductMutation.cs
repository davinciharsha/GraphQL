using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using GraphQLProject.Type;

namespace GraphQLProject.Mutations
{
    public class ProductMutation:ObjectGraphType
    {
        public ProductMutation(IProduct productService)
        {
            Field<ProductType>("createproduct",
                arguments: new QueryArguments(new QueryArgument<ProductInputType> { Name = "product" }),
                resolve: context =>
                {
                    return productService.AddProduct(context.GetArgument<Product>("product"));
                }
                );

            Field<ProductType>("updateproduct",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" },
                                              new QueryArgument<ProductInputType> { Name = "product" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var productObj = context.GetArgument<Product>("product");
                    return productService.UpdateProduct(id, productObj);
                }
                );
            Field<StringGraphType>("deleteproduct",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    productService.DeleteProduct(id);
                    return "The product against the given Id is deleted";
                }
                );
        }
    }
}
