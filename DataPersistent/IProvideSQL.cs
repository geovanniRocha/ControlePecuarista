using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;


namespace DataPersistent
{


    public abstract class IProvideSQL<T>{

        //string path = @"D:\mydb.db3";
        public SQLiteConnection connection {get; set;}

        public IProvideSQL(string path) {
            connection = new SQLiteConnection($"Data Source={path};Version=3;");
        }

        public IProvideSQL() {
            
        }
        

        public abstract void insert(T data);
        public abstract void update(T data);
        public abstract void delete(T data);
        public abstract T selectById(int id);
        public abstract List<T> selectEverything();

        public abstract void createTable();
        public abstract Dictionary<int, string> selectIdAndString();
    }

}
