using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceboxAssets.Model
{
    public class AppConfig
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
