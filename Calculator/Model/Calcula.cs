using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{

    internal class Calcula
    {
        public string memory_formula = "0" ;
        public string formula = "0";
        public List<string> formula_list = new List<string>() {"0"}; 
        [Obsolete]
        readonly Microsoft.JScript.Vsa.VsaEngine ve = Microsoft.JScript.Vsa.VsaEngine.CreateEngine();
        public object Cal(){
            string temp_formula = ""; 
            for(int i = 0; i < formula_list.Count(); i++){
                temp_formula += formula_list[i];
            }
            formula_list.Clear();
            formula = (Microsoft.JScript.Eval.JScriptEvaluate(temp_formula, ve)).ToString();
            formula_list.Add(formula); 
            return formula;
        }
        public bool Judge_last_operator(){
            try{
                if (formula_list[formula_list.Count-1] == "+" || formula_list[formula_list.Count - 1] == "-" || formula_list[formula_list.Count - 1] == "*" || formula_list[formula_list.Count - 1] == "/")
                {
                    formula_list.Add("0");
                    return true;
                }
                
            }
            catch{
                return false;
            }
            return false;
        }
        public void add_formula_operator(string Operator){
            if (!this.Judge_last_operator()){

                formula_list.Add(Operator);
            }
           
        }
        public void add_dot(){
            if (formula_list[formula_list.Count()-1].Contains(".") == false ){
                formula_list[formula_list.Count() - 1] += ".";
            }
        }
        public void Clear_Entry(){
            formula_list[formula_list.Count() - 1] = "0"; 
        }
        public void memory_plus(string number){
            memory_formula += "+" + number;
            memory_formula = (Microsoft.JScript.Eval.JScriptEvaluate(memory_formula, ve)).ToString(); 
        }
        public void memory_minus(string number) {
            memory_formula += "-" + number;
            memory_formula = (Microsoft.JScript.Eval.JScriptEvaluate(memory_formula, ve)).ToString(); ;
        }
        public void memory_recall(){
            if (this.Judge_last_operator() == true){
                formula_list.Add(memory_formula); 
            }
            else {
                formula_list[formula_list.Count() - 1] = memory_formula; 
            }
        }
        public void memory_clear()
        {
            memory_formula = "0"; 
        }
    }

}
