using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace DataPersistent
{
    public abstract class IProvideSQL<T>
    {

        public IProvideSQL(string path)
        {
            connection = new SQLiteConnection($"Data Source={path}; Version=3;");
        }

        public IProvideSQL()
        {
            connection = new SQLiteConnection($"Data Source=:memory:;Version=3;New=true;");
        }

        //string path = @"D:\mydb.db3";
        public SQLiteConnection connection { get; set; }

        public void runSQLWithOutReturn(string sql)
        {
            using (var c = new SQLiteConnection(connection))
            {
                try
                {
                    c.Open();
                    using (var cmd = new SQLiteCommand(sql, c))
                    {
#if DEBUG
                        DebugDLL.Debug.debug(sql); 
#endif
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {

#if DEBUG
                    DebugDLL.Debug.error("Exception: " + e.Message + " at: " + e.Source + " Stack Trace :" + e.StackTrace);
                    DebugDLL.Debug.warning("Sql : " + sql);     
#endif
                }
        }
        }

        public abstract void insert(T data);

        public abstract void update(T data);

        public abstract void delete(T data);

        public abstract void createTable();

        public abstract T selectById(int id);

        public abstract List<T> selectEverything();

        public Dictionary<int, string> selectIdAndString(string sql)
        {
            var tempDictionary = new Dictionary<int, string>();
            using (var c = new SQLiteConnection(connection))
            {
                c.Open();
                using (var cmd = new SQLiteCommand(sql, c))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tempid = reader.GetInt32(0);
                            var tempnome = reader.GetString(1);
                            tempDictionary.Add(tempid, tempnome);
                        }
                    }
                }
            }
            return tempDictionary;

        }
    }
}
