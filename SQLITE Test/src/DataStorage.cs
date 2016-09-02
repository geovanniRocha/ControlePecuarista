using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;

namespace Data_Persistent
{
    //TODO REFACTOR EVERYTHING
    public static class DataStorage
    {
        #region Data

        public class ControlePecuarista
        {
            #region Vars

            public List<DataTypes.Maquinario> maquinarioList;
            public List<DataTypes.Gastos> gastoList;
            public List<DataTypes.Combustivel> combustivelList;
            public List<DataTypes.Pastagem> pastagemList;
            public List<DataTypes.TipoPastagem> tipoPastagemList;
            public List<DataTypes.UnidadeAnimal> unidadeAnimalList;


            #endregion Vars

            #region Constructors and functions

            public ControlePecuarista()
            {
                maquinarioList = new List<DataTypes.Maquinario>();
                gastoList = new List<DataTypes.Gastos>();
                combustivelList = new List<DataTypes.Combustivel>();
                pastagemList = new List<DataTypes.Pastagem>();
                tipoPastagemList = new List<DataTypes.TipoPastagem>();
                unidadeAnimalList = new List<DataTypes.UnidadeAnimal>();
            }

           
            #endregion Constructors and functions

            #region CRUD Maquinario

            public void insertMaquinario(DataTypes.Maquinario maquinario)
            {
                maquinarioList.Add(maquinario);
            }

            public DataTypes.Maquinario findMaquinarioById(int id)
            {
                foreach (var maq in maquinarioList)
                    if (maq.id == id)
                        return maq;
                return null;
            }

            //TODO make a array, replace info and make another linkedlist, then replace, SHOULD be good, while not using thread
            //TODO, SO Not threadSafe this operation;
            public void replaceMaquinarioByID(DataTypes.Maquinario maquinario)
            {
               
            }

            #endregion CRUD Maquinario

            #region CRUD Gastos

            public void insertGastos(DataTypes.Gastos gasto)
            {
                gastoList.Add(gasto);
            }

            public DataTypes.Gastos findGastoByID(int id)
            {
                foreach (var gasto in gastoList)
                    if (gasto.id == id)
                        return gasto;
                return null;
            }

            public void replaceGastoByID(DataTypes.Gastos gasto)
            {
                throw new NotImplementedException();
            }

            #endregion CRUD Gastos

            #region CRUD Combustivel

            public void insertCombustivel(DataTypes.Combustivel combustivel)
            {
                combustivelList.Add(combustivel);
            }

            public DataTypes.Combustivel findCombustivelByID(int id)
            {
                foreach (var combustivel in combustivelList)
                    if (combustivel.id == id)
                        return combustivel;
                return null;
            }

            public void replaceCombustivelByID(DataTypes.Combustivel combustivel)
            {
                throw new NotImplementedException();
            }

            #endregion CRUD Combustivel

            #region CRUD Pastagem

            public void insertPastagem(DataTypes.Pastagem pastagem)
            {
                pastagemList.Add(pastagem);
            }

            public DataTypes.Pastagem findPastagemByID(int id)
            {
                foreach (var pasto in pastagemList)
                    if (pasto.id == id)
                        return pasto;
                return null;
            }

            public void replacePastagemByID(DataTypes.Pastagem pasto)
            {
                throw new NotImplementedException();
            }

            #endregion CRUD Pastagem

            #region CRUD TipoPastagem

            public void insertTipoPastagem(DataTypes.TipoPastagem tipoPastagem)
            {
                tipoPastagemList.Add(tipoPastagem);
            }

            public DataTypes.TipoPastagem findTipoPastagemByID(int id)
            {
                foreach (var pasto in tipoPastagemList)
                    if (pasto.id == id)
                        return pasto;
                return null;
            }

            public void replacePastagemByID(DataTypes.TipoPastagem tipoPasto)
            {
                throw new NotImplementedException();
            }

            #endregion CRUD TipoPastagem

            #region CRUD UnidadeAnimal

            public void insertUnidadeAnimal(DataTypes.UnidadeAnimal unidadeAnimal)
            {
                unidadeAnimalList.Add(unidadeAnimal);
            }

            public DataTypes.UnidadeAnimal findUnidadeNAnimalByID(int id)
            {
                foreach (var ua in unidadeAnimalList)
                    if (ua.id == id)
                        return ua;
                return null;
            }

            public void replaceUnidadeAnimalByID(DataTypes.UnidadeAnimal unidadeAnimal)
            {
                throw new NotImplementedException();
            }

            #endregion CRUD UnidadeAnimal
        }

        #endregion Data

        #region Helpers

        public static string readFile(string path, string fileName)
        {
            if (!File.Exists(path + "/" + fileName))
                return null;

            var sr = File.ReadAllText(path + "/" + fileName);
            return sr;
        }

        public static void writeFile(string texto, string path)
        {
            if (File.Exists(path))
                File.Delete(path);
            var sr = File.CreateText(path);
            sr.WriteLine(texto);
            sr.Close();
        }

        public static string jsonSerialize(ControlePecuarista controlePecuarista)
        {
            var temp = new JavaScriptSerializer();
            var b = temp.Serialize(controlePecuarista);

            return b;
        }

        #endregion Helpers
    }
}