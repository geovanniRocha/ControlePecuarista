using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;

namespace Data_Persistent
{
    //TODO REFACTOR EVERYTHING, CHANGE TO XML?
    public static class DataStorage
    {
        #region Data

        public class ControlePecuarista
        {
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

            #region Vars

            public List<DataTypes.Maquinario> maquinarioList;
            public List<DataTypes.Gastos> gastoList;
            public List<DataTypes.Combustivel> combustivelList;
            public List<DataTypes.Pastagem> pastagemList;
            public List<DataTypes.TipoPastagem> tipoPastagemList;
            public List<DataTypes.UnidadeAnimal> unidadeAnimalList;

            #endregion Vars

            #region CRUD Maquinario

            public void insertMaquinario(DataTypes.Maquinario maquinario)
            {
                maquinarioList.Add(maquinario);
            }

            public DataTypes.Maquinario findMaquinarioById(int id)
            {
                for (int i = 0; i < maquinarioList.Count; i++)
                    if (maquinarioList[i].id == id)
                        return maquinarioList[i];
                return null;
            }


            public void replaceMaquinarioByID(DataTypes.Maquinario maquinario)
            {
                for (int i = 0; i < maquinarioList.Count; i++)
                    if (maquinarioList[i].id == maquinario.id)
                        maquinarioList[i] = maquinario;

            }

            public void deleteMaquinarioByID(int id)
            {
                for (int i = 0; i < maquinarioList.Count; i++)
                    if (maquinarioList[i].id ==id)
                        maquinarioList[i] = null;

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
                for (int i = 0; i < gastoList.Count; i++)
                    if (gastoList[i].id == gasto.id)
                        gastoList[i] = gasto;

            }

            public void deleteGastoByID(int id)
            {
                for (int i = 0; i < gastoList.Count; i++)
                    if (gastoList[i].id == id)
                        gastoList[i] = null;

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
                for (int i = 0; i < combustivelList.Count; i++)
                    if (combustivelList[i].id == combustivel.id)
                        combustivelList[i] = combustivel;

            }

            public void deleteCombustivelByID(int id)
            {
                for (int i = 0; i < combustivelList.Count; i++)
                    if (combustivelList[i].id == id)
                        combustivelList[i] = null;

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

            public void replacePastagemByID(DataTypes.Pastagem pastagem)
            {
                for (int i = 0; i < pastagemList.Count; i++)
                    if (pastagemList[i].id == pastagem.id)
                        pastagemList[i] = pastagem;

            }

            public void deletePastagemByID(int id)
            {
                for (int i = 0; i < pastagemList.Count; i++)
                    if (pastagemList[i].id == id)
                        pastagemList[i] = null;

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

            public void replaceTipoPastagemByID(DataTypes.TipoPastagem tipoPastagem)
            {
                for (int i = 0; i < tipoPastagemList.Count; i++)
                    if (tipoPastagemList[i].id == tipoPastagem.id)
                        tipoPastagemList[i] = tipoPastagem;

            }

            public void deleteTipoPastagemByID(int id)
            {
                for (int i = 0; i < tipoPastagemList.Count; i++)
                    if (tipoPastagemList[i].id == id)
                        tipoPastagemList[i] = null;

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
                for (int i = 0; i < unidadeAnimalList.Count; i++)
                    if (unidadeAnimalList[i].id == unidadeAnimal.id)
                        unidadeAnimalList[i] = unidadeAnimal;

            }

            public void deleteUnidadeAnimalByID(int id)
            {
                for (int i = 0; i < unidadeAnimalList.Count; i++)
                    if (unidadeAnimalList[i].id == id)
                        unidadeAnimalList[i] = null;

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

        public static string readFile(Stream stream)
        {
            
            return " ";

        }



        public static void writeFile(string texto, string path)
        {
            if (File.Exists(path))
                File.Delete(path);
            var sr = File.CreateText(path);
            sr.WriteLine(texto);
            sr.Close();
        }
        public static void writeFile(Stream stream, string texto, string path)
        {
            byte[] toBytes = Encoding.ASCII.GetBytes(texto);
            stream.Write(toBytes, 0, toBytes.Length);
            stream.Dispose();
            stream.Close();
            toBytes = null;
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