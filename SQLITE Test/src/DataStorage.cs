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

            private readonly LinkedList<DataTypes.Maquinario> maquinarioList;
            private readonly LinkedList<DataTypes.Gastos> gastoList;
            private readonly LinkedList<DataTypes.Combustivel> combustivelList;
            private readonly LinkedList<DataTypes.Pastagem> pastagemList;
            private readonly LinkedList<DataTypes.TipoPastagem> tipoPastagemList;
            private readonly LinkedList<DataTypes.UnidadeAnimal> unidadeAnimalList;

            public DataTypes.Maquinario[] maquinarios;
            public DataTypes.Gastos[] gastos;
            public DataTypes.Combustivel[] combustivels;
            public DataTypes.Pastagem[] pastagems;
            public DataTypes.TipoPastagem[] tipoPastagens;
            public DataTypes.UnidadeAnimal[] unidadeAnimals;

            #endregion Vars

            #region Constructors and functions

            public ControlePecuarista()
            {
                maquinarioList = new LinkedList<DataTypes.Maquinario>();
                gastoList = new LinkedList<DataTypes.Gastos>();
                combustivelList = new LinkedList<DataTypes.Combustivel>();
                pastagemList = new LinkedList<DataTypes.Pastagem>();
                tipoPastagemList = new LinkedList<DataTypes.TipoPastagem>();
                unidadeAnimalList = new LinkedList<DataTypes.UnidadeAnimal>();
            }

            public void toJson()
            {
                maquinarios = maquinarioList.ToArray();
                gastos = gastoList.ToArray();
                combustivels = combustivelList.ToArray();
                pastagems = pastagemList.ToArray();
                tipoPastagens = tipoPastagemList.ToArray();
                unidadeAnimals = unidadeAnimalList.ToArray();
            }

            #endregion Constructors and functions

            #region CRUD Maquinario

            public void insertMaquinario(DataTypes.Maquinario maquinario)
            {
                maquinarioList.AddLast(maquinario);
            }

            public DataTypes.Maquinario findMaquinarioById(int id)
            {
                maquinarios = maquinarioList.ToArray();
                foreach (var maq in maquinarioList)
                    if (maq.id == id)
                        return maq;
                return null;
            }

            //TODO make a array, replace info and make another linkedlist, then replace, SHOULD be good, while not using thread
            //TODO, SO Not threadSafe this operation;
            public void replaceMaquinarioByID(DataTypes.Maquinario maquinario)
            {
                for (var node = maquinarioList.First; node != maquinarioList.Last.Next; node = node.Next)
                {
                    if (node.Value.id == maquinario.id)
                        node.Value = maquinario;
                }
            }

            #endregion CRUD Maquinario

            #region CRUD Gastos

            public void insertGastos(DataTypes.Gastos gasto)
            {
                gastoList.AddLast(gasto);
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
                combustivelList.AddLast(combustivel);
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
                pastagemList.AddLast(pastagem);
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
                tipoPastagemList.AddLast(tipoPastagem);
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
                unidadeAnimalList.AddLast(unidadeAnimal);
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
            controlePecuarista.toJson();
            var temp = new JavaScriptSerializer();
            var b = temp.Serialize(controlePecuarista);

            return b;
        }

        #endregion Helpers
    }
}