using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;

namespace Data_Persistent
{
    //TODO REFACTOR EVERYTHING, CHANGE TO SQL?
    //Refactor, usar heranca para definir a interface, definindo assim a 
    public static class DataStorage
    {
        #region Data

        public class ControlePecuarista
        {
            #region Constructors and functions

            public ControlePecuarista()
            {

            }

            #endregion Constructors and functions

            #region Vars

            #endregion Vars

            #region CRUD Maquinario

            public void insertMaquinario(DataTypes.Maquinario maquinario) {
                string SQL = $"insert into maquinarios(id, nome, descricao, valor) values ('{maquinario.id}', '{maquinario.nome}', '{maquinario.descricao}', '{maquinario.valor}')";
                //TOOD make it run.    
            }

            public DataTypes.Maquinario findMaquinarioById(int id) {
                string SQL = $"Select * from maquinario where id = {id};";
                return null;
            }


            public void replaceMaquinarioByID(DataTypes.Maquinario maquinario) {
                string SQL = $"Update maquinario set ('{maquinario.id}', '{maquinario.nome}', '{maquinario.descricao}', '{maquinario.valor}') where id = {maquinario.id};";

            }

            public void deleteMaquinarioByID(int id) {
                string SQL = "";

            }

            #endregion CRUD Maquinario

            #region CRUD Gastos

            public void insertGastos(DataTypes.Gastos gasto)
            {
                string SQL = $"insert into maquinarios(id, nome, descricao, valor) values ('{gasto.id}', '{gasto.nome}', '{gasto.descricao}', '{gasto.valor}')";

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