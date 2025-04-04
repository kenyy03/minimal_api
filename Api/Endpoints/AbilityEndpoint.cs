using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using Application.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos.Ability;

namespace Api.Endpoints
{
    public static class AbilityEndpoint
    {
        public static WebApplication MapAbilityEndpoints(this WebApplication app)
        {
            var root = app.MapGroup("/api/ability")
                .WithTags("ability")
                .WithDescription("Lookup and Find Abilities")
                .WithOpenApi();

            _ = root.MapGet("/", GetAllAbilities)
                .Produces<List<AbilityDto>>()
                .ProducesProblem(StatusCodes.Status500InternalServerError)
                .WithSummary("Lookup all Abilities")
                .WithDescription("\n    GET /ability");

            _ = root.MapPost("/create", CreateAbility)
                .Produces<AbilityDto>()
                .ProducesProblem(StatusCodes.Status500InternalServerError)
                .WithSummary("Create an Ability")
                .WithDescription("\n    POST /ability");

            _ = root.MapPut("/update", UpdateAbility)
                .Produces<AbilityDto>()
                .ProducesProblem(StatusCodes.Status500InternalServerError)
                .WithSummary("Update an Ability")
                .WithDescription("\n    POST /update-ability");

            _ = root.MapDelete("/delete/{id}", DeleteAbility)
                .Produces<Guid>()
                .ProducesProblem(StatusCodes.Status500InternalServerError)
                .WithSummary("Delete an Ability")
                .WithDescription("\n    DELETE /delete-ability");

            return app;
        }

        public static async Task<IResult> GetAllAbilities(AbilityService service)
        {
            try
            {
                return Results.Ok(await service.GetAllAbilities());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public static async Task<IResult> CreateAbility(AbilityService service, [FromBody] CreateAbilityRequest request)
        {
            try
            {
                return Results.Ok(await service.CreateAbility(request));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public static async Task<IResult> UpdateAbility(AbilityService service, [FromBody] AbilityDto request)
        {
            try
            {
                return Results.Ok(await service.UpdateAbility(request));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public static async Task<IResult> DeleteAbility(AbilityService service, [FromRoute] Guid id)
        {
            try
            {
                return Results.Ok(await service.DeleteAbility(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}
