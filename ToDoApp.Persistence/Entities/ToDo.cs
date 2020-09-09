using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace ToDoApp.Persistence.Entities
{
    [Table("todo")]
    public class ToDo
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [ForeignKey(typeof(ToDoStatus))]
        [Column("status_id")]
        public int StatusId { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public ToDoStatus Status { get; set; }
    }
}