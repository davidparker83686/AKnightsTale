using System;
using System.Collections.Generic;
using System.Data;
using AKnightsTale.Models;
using Dapper;

namespace AKnightsTale.Repositories
{
  public class CastlesRepository
  {
    private readonly IDbConnection _db;
    public CastlesRepository(IDbConnection db)
    {
      _db = db;
    }
    // -----------------------------------------------------------------------------------------------------------------
    internal IEnumerable<Castle> GetAll()
    {
      string sql = "SELECT * FROM castle";
      // QUERY returns a collection
      return _db.Query<Castle>(sql);
    }
    // -----------------------------------------------------------------------------------------------------------------
    internal Castle GetById(int id)
    {
      // Dapper uses '@' to indicate a variable that can be safeley injectected in the Query arguments
      string sql = "SELECT * FROM castle WHERE id = @id";
      //   Query first or default returns a single item or null


      // ????????????????????????????????????
      return _db.QueryFirstOrDefault<Castle>(sql, new { id });
    }
    // --------------------------------------------------------------------------------------------------------------
    internal Castle Create(Castle newCastle)
    {
      string sql = @"
        INSERT INTO castle
        --this is looking at whats goin on on the table. so it needs to match spelling and order
        (id, name)
        VALUES
        (@Id, @Name);
        SELECT LAST_INSERT_ID()";
      newCastle.Id = _db.ExecuteScalar<int>(sql, newCastle);
      return newCastle;
    }
    // -----------------------------------------------------------------------------------------------------------------
    internal bool Update(Castle original)
    {
      string sql = @"
      UPDATE castle
      SET
        id = @Id
        name = @Name
      WHERE id=@Id
      ";
      int affectedRows = _db.Execute(sql, original);
      return affectedRows == 1;
    }
    // internal Castle Edit(Castle updatedCastle)
    // {
    //   string sql = @"
    //   UPDATE castle
    //   SET
    //     id = @Id
    //     name = @Name
    //   WHERE id=@Id;
    //   SELECT * FROM Castles Where Id =@id LIMIT 1;2";
    //   int affectedRows = _db.Execute(sql, original);
    //   return affectedRows == 1;
    // }
    // ---------------------------------------------------------------------------------------------------------------
    internal bool Delete(int id)
    {
      // Dapper uses '@' to indicate a variable that can be safeley injectected in the Query arguments
      string sql = "DELETE FROM castle WHERE id = @id LIMIT 1";
      //   Query first or default returns a single item or null
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows == 1;
    }
  }
}