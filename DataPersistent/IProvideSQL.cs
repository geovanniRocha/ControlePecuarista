using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace DataPersistent
{


    abstract class IProvideSQL<T> {
        const string path = @"D:\mydb.db3";
        public string connection {get; set;}

        public IProvideSQL() {
            connection = ($"Data Source={path};Version=3;");
        }
        

        public abstract void insert(T data);
        public abstract void update(T data);
        public abstract void delete(T data);
        public abstract T selectById(int id);
        public abstract void createTable();

    }

}
