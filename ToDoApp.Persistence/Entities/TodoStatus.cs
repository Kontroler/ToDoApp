using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace ToDoApp.Persistence.Entities
{
    [Table("todo")]
    public class ToDoStatus
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [OneToMany]
        public List<ToDo> ToDos { get; set; }
    }
}
