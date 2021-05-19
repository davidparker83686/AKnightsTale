using System;
using System.Collections.Generic;
using AKnightsTale.Models;
using AKnightsTale.Repositories;

namespace AKnightsTale.Services
{
  public class CastlesService
  {
    private readonly CastlesRepository _repo;

    public CastlesService(CastlesRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Castle> GetAll()
    {
      return _repo.GetAll();
    }

    internal Castle GetById(int id)
    {
      Castle castle = _repo.GetById(id);
      if (castle == null)
      {
        throw new Exception("Invalid Id");
      }
      return castle;
    }

    internal Castle Create(Castle newCastle)
    {
      Castle castle = _repo.Create(newCastle);
      return castle;
    }

    internal Castle Update(Castle update)
    {
      Castle original = GetById(update.Id);

      original.Id = update.Id > 0 ? update.Id : original.Id;
      original.Name = update.Name.Length > 0 ? update.Name : original.Name;

      if (_repo.Update(original))
      {
        return original;
      }
      throw new Exception("Something Went Wrong???");
    }

    internal void DeleteCastle(int id)
    {
      GetById(id);
      _repo.Delete(id);
    }
  }
}