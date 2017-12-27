using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
//using SQLiteNetExtensions.Attributes;

namespace IceboxAssets.Model
{
    [Table("Members")]
    public class Member
    {
        [PrimaryKey]
        public Guid MemberId { get; set; }
        public string MemberName { get; set; }
        
    }
}
