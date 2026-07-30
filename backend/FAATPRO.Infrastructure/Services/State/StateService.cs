using FAATPRO.Application.Features.States.DTOs;
using FAATPRO.Application.Features.States.Interfaces;

using StateEntity = FAATPRO.Domain.Entities.State;

using FAATPRO.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;


namespace FAATPRO.Infrastructure.Services.State;


public class StateService : IStateService
{

    private readonly ApplicationDbContext _context;


    public StateService(
        ApplicationDbContext context)
    {
        _context = context;
    }



    public async Task<List<StateResponse>> GetAllAsync()
    {

        return await _context.States

            .Select(x => new StateResponse
            {

                Id = x.Id,

                CountryId = x.CountryId,

                Code = x.Code,

                Name = x.Name,

                IsActive = x.IsActive,

                CreatedAt = x.CreatedAt

            })

            .ToListAsync();

    }





    public async Task<StateResponse?> GetByIdAsync(
        Guid id)
    {

        var state =
            await _context.States
            .FirstOrDefaultAsync(x => x.Id == id);


        if (state == null)
            return null;


        return new StateResponse
        {

            Id = state.Id,

            CountryId = state.CountryId,

            Code = state.Code,

            Name = state.Name,

            IsActive = state.IsActive,

            CreatedAt = state.CreatedAt

        };

    }





    public async Task<StateResponse> CreateAsync(
        CreateStateRequest request)
    {

        var state = new StateEntity
        {

            Id = Guid.NewGuid(),

            CountryId = request.CountryId,

            Code = request.Code,

            Name = request.Name,

            IsActive = request.IsActive

        };


        await _context.States.AddAsync(state);


        await _context.SaveChangesAsync();



        return await GetByIdAsync(state.Id)
            ?? throw new Exception(
                "State creation failed");

    }





    public async Task<bool> UpdateAsync(
        Guid id,
        CreateStateRequest request)
    {

        var state =
            await _context.States
            .FirstOrDefaultAsync(x => x.Id == id);



        if (state == null)
            return false;



        state.CountryId = request.CountryId;

        state.Code = request.Code;

        state.Name = request.Name;

        state.IsActive = request.IsActive;



        await _context.SaveChangesAsync();


        return true;

    }





    public async Task<bool> DeleteAsync(
        Guid id)
    {

        var state =
            await _context.States
            .FirstOrDefaultAsync(x => x.Id == id);



        if (state == null)
            return false;



        _context.States.Remove(state);


        await _context.SaveChangesAsync();


        return true;

    }

}