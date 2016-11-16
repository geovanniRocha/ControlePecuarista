using System;
using DataPersistent;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GeradorRelatorio
{
    public class HTMLBuilder {
        private readonly StringBuilder html;

        public HTMLBuilder() {
            html = new StringBuilder();
        }

        public void breakLine() {
            html.Append("<br>");
        }

        public void addButton(string nome) {
            html.Append(@"<a class='pure-button color-energized' href='#" + nome + "'>" + nome + "</a>");
        }

        [Obsolete("use another initDiv", true)]
        public void initDiv(string divname) {
            html.Append(@"<div class = 'separator'id='" + divname + "'>");
        }

        public void initDiv(string divname, string classname) {
            html.Append($"<div class = '{classname}'id='{divname}'>");
        }

        public void endDiv() {
            html.Append("</div>");
        }

        public void addMaquinariosTable(List<Maquinario> data) {
            html.Append(@"<table  class='pure-table pure-table-bordered '>");
            html.Append("<thead>");

            html.Append($"<th>ID</th>");
            html.Append($"<th>Nome</th>");
            html.Append($"<th>Descricao</th>");

            html.Append("</thead>");

            html.Append("<tbody>");
            foreach (var me in data)
            {
                html.Append("<tr>");
                html.Append($"<td>{me.id}</td>");
                html.Append($"<td>{me.nome}</td>");
                html.Append($"<td>{me.descricao}</td>");
                html.Append("</tr>");
            }
            html.Append("</tbody>");

            html.Append(@"</table>");
        }

        public string toHTML() {
            return html.ToString();
        }

        public void css() {
#if DEBUG

            using (StreamReader sr = new StreamReader(@"D:/css.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    html.Append(line);
                }
            }
#else
            html.Append(@"<style>.pure-button{display:inline-block;zoom:1;line-height:normal;white-space:nowrap;vertical-align:middle;text-align:center;cursor:pointer;-webkit-user-drag:none;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none;-webkit-box-sizing:border-box;-moz-box-sizing:border-box;box-sizing:border-box;font-family:inherit;font-size:100%;padding:.5em 1em;color:#444;color:rgba(0,0,0,.8);border:1px solid #999;border:transparent;background-color:#E6E6E6;text-decoration:none;border-radius:3px}.pure-button-hover,.pure-button:focus,.pure-button:hover{filter:progid: DXImageTransform.Microsoft.gradient(startColorstr='#00000000', endColorstr='#1a000000', GradientType=0);background-image:-webkit-gradient(linear,0 0,0 100%,from(transparent),color-stop(40%,rgba(0,0,0,.05)),to(rgba(0,0,0,.1)));background-image:-webkit-linear-gradient(transparent,rgba(0,0,0,.05) 40%,rgba(0,0,0,.1));background-image:-moz-linear-gradient(top,rgba(0,0,0,.05) 0,rgba(0,0,0,.1));background-image:-o-linear-gradient(transparent,rgba(0,0,0,.05) 40%,rgba(0,0,0,.1));background-image:linear-gradient(transparent,rgba(0,0,0,.05) 40%,rgba(0,0,0,.1))}.color-calm{background-color:#387ef5}.color-energized{background-color:#ffc900}.pure-table{width:100%;border-collapse:collapse;border-spacing:0;empty-cells:show;border:1px solid #cbcbcb}.pure-table td,.pure-table th{border-left:1px solid #cbcbcb;border-width:0 0 0 1px;font-size:inherit;margin:0;overflow:visible;padding:.5em 1em}.pure-table-bordered td{border-bottom:1px solid #cbcbcb}.pure-table-bordered tbody>tr:last-child>td{border-bottom-width:0}.pure-table thead{background-color:#e0e0e0;color:#000;text-align:left;vertical-align:bottom}.separator{overflow:hidden;margin:20px 10px;border-radius:2px;background-color:#fff;padding-top:1px;box-shadow:0 1px 3px rgba(0,0,0,.3)}.division{padding:10px}</style>");

#endif
        }

        public void addPastagemTable(List<Pastagem> data) {
            html.Append(@"<table  class='pure-table pure-table-bordered '>");
            html.Append("<thead>");

            html.Append($"<th>ID</th>");
            html.Append($"<th>Nome</th>");
            html.Append($"<th>Área Util</th>");
            html.Append($"<th>ID Pastagem</th>");

            html.Append("</thead>");

            html.Append("<tbody>");
            foreach (var me in data)
            {
                html.Append("<tr>");
                html.Append($"<td>{me.id}</td>");
                html.Append($"<td>{me.nome}</td>");
                html.Append($"<td>{me.areaUtil}</td>");
                html.Append($"<td>{me.tipoPastagemID}</td>");
                html.Append("</tr>");
            }
            html.Append("</tbody>");

            html.Append(@"</table>");
        }

        public void addGastosTable(List<Gastos> data) {
            html.Append(@"<table  class='pure-table pure-table-bordered '>");
            html.Append("<thead>");

            html.Append($"<th>ID</th>");
            html.Append($"<th>Nome</th>");
            html.Append($"<th>Descricao</th>");
            html.Append($"<th>ID Pastagem</th>");
            html.Append($"<th>ID Ref</th>");
            html.Append($"<th>ID Valor</th>");

            html.Append("</thead>");

            html.Append("<tbody>");
            foreach (var me in data)
            {
                html.Append("<tr>");

                html.Append($"<td>{me.id}</td>");
                html.Append($"<td>{me.nome}</td>");
                html.Append($"<td>{me.descricao}</td>");
                html.Append($"<td>{me.idCategoria}</td>");
                html.Append($"<td>{me.idRef}</td>");
                html.Append($"<td>{me.valor}</td>");

                html.Append("</tr>");
            }
            html.Append("</tbody>");

            html.Append(@"</table>");
        }

        public void addUnidadeAnimalTable(List<UnidadeAnimal> data) {
            html.Append(@"<table  class='pure-table pure-table-bordered '>");
            html.Append("<thead>");

            html.Append($"<th>ID</th>");
            html.Append($"<th>Nome</th>");
            html.Append($"<th>Raca</th>");
            html.Append($"<th>UA Entrada</th>");
            html.Append($"<th>UA Saida</th>");

            html.Append($"<th>Data Entrada</th>");
            html.Append($"<th>Data Saida</th>");

            html.Append($"<th>Valor</th>");

            html.Append("</thead>");

            html.Append("<tbody>");
            foreach (var me in data)
            {
                html.Append("<tr>");

                html.Append($"<td>{me.id}</td>");
                html.Append($"<td>{me.nome}</td>");
                html.Append($"<td>{me.raca}</td>");
                html.Append($"<td>{me.uaEntrada}</td>");
                html.Append($"<td>{me.uaSaida}</td>");
                html.Append($"<td>{DateTime.FromFileTimeUtc(me.dataEntrada)}</td>");
                html.Append($"<td>{DateTime.FromFileTimeUtc(me.dataSaida)}</td>");

                html.Append($"<td>{me.valor}</td>");

                html.Append("</tr>");
            }
            html.Append("</tbody>");

            html.Append(@"</table>");
        }


        public void clear() {
            html.Clear();
        }
    }
}