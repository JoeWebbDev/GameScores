using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameScores.DAL
{
    public class BaseRepository
    {
        protected readonly string ConnectionString;
        protected BaseRepository(IOptions<DatabaseOptions> databaseOptions)
        {
             ConnectionString = databaseOptions.Value.ConnectionString;
        }
    }
}
