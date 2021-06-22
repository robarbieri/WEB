	function Clear(p_strField, p_strValue){
			document.forms[0][p_strField].value = p_strValue;
	}
	
	function ClearAll(p_objTr){
            document.forms[0].txtCPF.value = "";
            document.forms[0].txtNome.value = "";
            document.forms[0].txtDDD.value = "";
            document.forms[0].txtFone.value = "";
            document.forms[0].txtCEP.value = "";
            document.forms[0].txtEndereco.value = "";
            document.forms[0].txtNumero.value = "";
            document.forms[0].txtComplemento.value = "";
            document.forms[0].txtCidade.value = "";
            document.forms[0].txtBairro.value = "";
	}

	function setForm(p_strField, p_strValue){
		if((document.forms[0].txtCPF.value == "") && ((document.forms[0]["cboUF"].value.toUpperCase() == "TODOS" && p_strField != "CPF" && p_strField != "UF"))){
			alert("Para fazer busca por este campo, selecione um estado que não seja Todos")
			return false;
		}else{
			var strPrefix = "txt";

			if(p_strField.toUpperCase() == "UF")
				strPrefix = "cbo";
            
			document.forms[0][strPrefix + p_strField].value = p_strValue;
		}
		
		return true;
	}

	function setFormAll(p_objTr){
		if(	(document.forms[0].txtCPF.value == "") && (document.forms[0]["cboUF"].value.toUpperCase() == "TODOS")){
			alert("Para fazer busca por este campo, selecione um estado que não seja Todos")
			return false;
		}
		
		for(var i = 0;i < p_objTr.childNodes.length;i++){
			var strField = p_objTr.childNodes[i].id.replace(/td/,"");
			//strField.replace(/td/,"");

			if(strField.toUpperCase() != "TIPO" && (strField.toUpperCase() != "TODOS"))
				setForm(strField.replace("Compl","Complemento"), p_objTr.childNodes[i].innerText);
		}
		
		return true;
		
	}
	function paintLine(p_objTr, p_blnFlag){
		if(p_blnFlag){
			p_objTr.style.backgroundColor = "#FFC080";
		}else{
			p_objTr.style.backgroundColor = "";
		}
	}
	
//    function ExecutaBuscar()
//	    {
//	        document.getElementById("resposta").innerHTML = "Carregando.......Aguarde."
//	        document.forms[0].btnBuscar.disabled = true;
//	        document.forms[0].btnProximidades.disabled = true;
//	        document.forms[0].Button1.disabled = true;
//            document.forms[0].Button2.disabled = true;
//            document.forms[0].Button3.disabled = true;
//            document.forms[0].Button4.disabled = true;
//            document.forms[0].Button5.disabled = true;
//            document.forms[0].Button6.disabled = true;
//            document.forms[0].Button7.disabled = true;
//            document.forms[0].Button8.disabled = true;
//            document.forms[0].Button9.disabled = true;
//            document.forms[0].Button10.disabled = true;
//            document.forms[0].Button11.disabled = true;
//            document.forms[0].Map.disabled = true;
//		    Pesquisa.Buscar(0,
//		                document.forms[0].txtCPF.value,
//                        document.forms[0].txtNome.value,
//                        document.forms[0].txtDDD.value,
//                        document.forms[0].txtFone.value,
//                        document.forms[0].txtCEP.value,
//                        document.forms[0].txtEndereco.value,
//                        document.forms[0].txtNumero.value,
//                        document.forms[0].txtComplemento.value,
//                        document.forms[0].txtCidade.value,
//                        document.forms[0].txtBairro.value,
//                        document.forms[0].cboQtd.value,
//                        document.forms[0].cboUF.value,
//                        document.forms[0].txtUsuario.value,
//		    Buscar_CallBack);
//	    }  	
//	    		
//    function Buscar_CallBack(response)
//	    {
//	        document.forms[0].btnBuscar.disabled = "";
//	        document.forms[0].btnProximidades.disabled = "";
//	        document.forms[0].Button1.disabled = "";
//            document.forms[0].Button2.disabled = "";
//            document.forms[0].Button3.disabled = "";
//            document.forms[0].Button4.disabled = "";
//            document.forms[0].Button5.disabled = "";
//            document.forms[0].Button6.disabled = "";
//            document.forms[0].Button7.disabled = "";
//            document.forms[0].Button8.disabled = "";
//            document.forms[0].Button9.disabled = "";
//            document.forms[0].Button10.disabled = "";
//            document.forms[0].Button11.disabled = "";
//            document.forms[0].Map.disabled = "";
//		    document.getElementById("resposta").innerHTML = response.value;
//	    }
//	    
//	function ExecutaBuscarProx()
//	    {
//	        document.getElementById("resposta").innerHTML = "Carregando.......Aguarde."
//	        document.forms[0].btnBuscar.disabled = true;
//	        document.forms[0].btnProximidades.disabled = true;
//	        document.forms[0].Button1.disabled = true;
//            document.forms[0].Button2.disabled = true;
//            document.forms[0].Button3.disabled = true;
//            document.forms[0].Button4.disabled = true;
//            document.forms[0].Button5.disabled = true;
//            document.forms[0].Button6.disabled = true;
//            document.forms[0].Button7.disabled = true;
//            document.forms[0].Button8.disabled = true;
//            document.forms[0].Button9.disabled = true;
//            document.forms[0].Button10.disabled = true;
//            document.forms[0].Button11.disabled = true;
//            document.forms[0].Map.disabled = true;
//		    Pesquisa.Buscar(1,
//		                document.forms[0].txtCPF.value,
//                        document.forms[0].txtNome.value,
//                        document.forms[0].txtDDD.value,
//                        document.forms[0].txtFone.value,
//                        document.forms[0].txtCEP.value,
//                        document.forms[0].txtEndereco.value,
//                        document.forms[0].txtNumero.value,
//                        document.forms[0].txtComplemento.value,
//                        document.forms[0].txtCidade.value,
//                        document.forms[0].txtBairro.value,
//                        document.forms[0].cboQtd.value,
//                        document.forms[0].cboUF.value,
//                        document.forms[0].txtUsuario.value,
//		    BuscarProx_CallBack);
//	    }  		
//	    	
//    function BuscarProx_CallBack(response)
//	    {
//	        document.forms[0].btnBuscar.disabled = "";
//	        document.forms[0].btnProximidades.disabled = "";
//	        document.forms[0].Button1.disabled = "";
//            document.forms[0].Button2.disabled = "";
//            document.forms[0].Button3.disabled = "";
//            document.forms[0].Button4.disabled = "";
//            document.forms[0].Button5.disabled = "";
//            document.forms[0].Button6.disabled = "";
//            document.forms[0].Button7.disabled = "";
//            document.forms[0].Button8.disabled = "";
//            document.forms[0].Button9.disabled = "";
//            document.forms[0].Button10.disabled = "";
//            document.forms[0].Button11.disabled = "";
//            document.forms[0].Map.disabled = "";
//		    document.getElementById("resposta").innerHTML = response.value;
//	    }
	    
	function CarregarMapa()
	    {
//	    if (trim(document.forms[0].txtUsuario.value)!="Master" && trim(document.forms[0].txtUsuario.value)!="Mara Silva" && trim(document.forms[0].txtUsuario.value)!="Décio C. Souza")
//	        {
//	        alert("Este usuário não pode utilizar este recurso.");
//	        }
//	        else
//	        {
	        if(validaCampos())
		        {                                
                    popupcenter('inMapa.aspx?end=' + trim(document.forms[0].txtNumero.value) + ' '
                                           + trim(document.forms[0].txtEndereco.value) + ','
                                           + trim(document.forms[0].txtCidade.value) + ','
                                           + trim(document.forms[0].cboUF.value) + '&cpf=CPF: '
                                           + trim(document.forms[0].txtCPF.value) + '&nome=Nome: '
                                           + trim(document.forms[0].txtNome.value) + '&endereco=Endereço: '
                                           + trim(document.forms[0].txtEndereco.value) + ', ' + trim(document.forms[0].txtNumero.value) + ' ' + trim(document.forms[0].txtComplemento.value) + '&bairro=Bairro: '
                                           + trim(document.forms[0].txtBairro.value) + '&cep=CEP: '
                                           + trim(document.forms[0].txtCEP.value) + '&cidade=Cidade: '
                                           + trim(document.forms[0].txtCidade.value) + '&uf=UF: '
                                           + trim(document.forms[0].cboUF.value) + '&pais=País: Brasil'
                                           ,'Mapa',580,400,0,0);
	            }
	        else
	            {
	            alert("Para visualizar o mapa, preencha os campos ENDEREÇO, NÚMERO, CIDADE e UF.");
	            }
//	        }
        }
	        
    function popupcenter(Url,Name,PosFimX,PosFimY,ScrollBars,Resizable)
        {

          PosIniX=((screen.availWidth/2)-(PosFimX/2));

          PosIniY=((screen.availHeight/2)-(PosFimY/2));

          window.open(Url,Name,'toolbar=0,location=0,directories=0,menubar=0,scrollbars='+ScrollBars+',resizable='+Resizable+',top='+PosIniY+',left='+PosIniX+',width='+PosFimX+',height='+PosFimY+'');

        }
	    
	function validaCampos()
	    {
	        if(document.forms[0].txtNumero.value==""){
			    return false;
		    }
    		
		    if(document.forms[0].txtEndereco.value==""){
			    return false;
		    }
    		
		    if(document.forms[0].txtCidade.value==""){
			    return false;
		    }
		return true;
	    }
		
	function fnFormatContrato()
		{
		try
			{
			with(window.event.srcElement)
				{
				maxLength = 19
				if((event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105) && event.keyCode != 17 && event.keyCode != 86 && event.keyCode != 16 && event.keyCode != 46 && event.keyCode != 8 && event.keyCode != 37 && event.keyCode != 9)
					{
					event.returnValue = false;		
					}			
				if((value.length == 4 || value.length == 9 || value.length == 14) && event.keyCode != 8)
					{
					value += ".";
					}
				}				
			}	
		catch(e)
			{
			event.returnValue = false;
			}
		}
		
	function fnFormatCartao()
		{
		try
			{
			with(window.event.srcElement)
				{
				maxLength = 19
				if((event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105) && event.keyCode != 17 && event.keyCode != 86 && event.keyCode != 16 && event.keyCode != 46 && event.keyCode != 8 && event.keyCode != 37 && event.keyCode != 9)
					{
					event.returnValue = false;		
					}			
				if((value.length == 4 || value.length == 9 || value.length == 14) && event.keyCode != 8)
					{
					value += " ";
					}
				}				
			}	
		catch(e)
			{
			event.returnValue = false;
			}
		}
		
    function Replace(Expression, Find, Replace)
        {
	        var temp = Expression;
	        var a = 0;

	        for (var i = 0; i < Expression.length; i++) 
	        {
		        a = temp.indexOf(Find);
		        if (a == -1){
			        break
			    }
		        else{
			        temp = temp.substring(0, a) + Replace + temp.substring((a + Find.length));
				    }
	        }
	        return temp;
        }
        
            function FormataValor(campo,tammax,teclapres) {
	    var tecla = teclapres.keyCode;
    //	vr = document.form1.item(campo).value;
	    vr = document.form1.elements[campo].value
	    vr = vr.replace( "/", "" );
	    vr = vr.replace( "/", "" );
	    vr = vr.replace( ",", "" );
	    vr = vr.replace( ".", "" );
	    vr = vr.replace( ".", "" );
	    vr = vr.replace( ".", "" );
	    vr = vr.replace( ".", "" );
	    tam = vr.length;

	    if (tam < tammax && tecla != 8){ tam = vr.length + 1 ; }

	    if (tecla == 8 ){	tam = tam - 1 ; }
    		
	    if ( tecla == 8 || tecla >= 48 && tecla <= 57 || tecla >= 96 && tecla <= 105 ){
		    if ( tam <= 2 ){ 
	 		    document.form1.elements[campo].value = vr ; }
	 	    if ( (tam > 2) && (tam <= 5) ){
	 		    document.form1.elements[campo].value = vr.substr( 0, tam - 2 ) + ',' + vr.substr( tam - 2, tam ) ; }
	 	    if ( (tam >= 6) && (tam <= 8) ){
	 		    document.form1.elements[campo].value = vr.substr( 0, tam - 5 ) + '.' + vr.substr( tam - 5, 3 ) + ',' + vr.substr( tam - 2, tam ) ; }
	 	    if ( (tam >= 9) && (tam <= 11) ){
	 		    document.form1.elements[campo].value = vr.substr( 0, tam - 8 ) + '.' + vr.substr( tam - 8, 3 ) + '.' + vr.substr( tam - 5, 3 ) + ',' + vr.substr( tam - 2, tam ) ; }
	 	    if ( (tam >= 12) && (tam <= 14) ){
	 		    document.form1.elements[campo].value = vr.substr( 0, tam - 11 ) + '.' + vr.substr( tam - 11, 3 ) + '.' + vr.substr( tam - 8, 3 ) + '.' + vr.substr( tam - 5, 3 ) + ',' + vr.substr( tam - 2, tam ) ; }
	 	    if ( (tam >= 15) && (tam <= 17) ){
	 		    document.form1.elements[campo].value = vr.substr( 0, tam - 14 ) + '.' + vr.substr( tam - 14, 3 ) + '.' + vr.substr( tam - 11, 3 ) + '.' + vr.substr( tam - 8, 3 ) + '.' + vr.substr( tam - 5, 3 ) + ',' + vr.substr( tam - 2, tam ) ;}
	    }	
    }

    function ReFormataValor(campo,tammax,teclapres) {
	    var tecla = teclapres.keyCode;
    //	vr = document.form1.item(campo).value;
	    vr = document.form1.elements[campo].value;
	    vr = vr.replace( "/", "" );
	    vr = vr.replace( "/", "" );
	    vr = vr.replace( ",", "" );
	    vr = vr.replace( ".", "" );
	    vr = vr.replace( ".", "" );
	    vr = vr.replace( ".", "" );
	    vr = vr.replace( ".", "" );
    	
	    tam = vr.length;

	    vr2 = vr.substr(tam - 1, tam);
    	
	    if (vr2 != '.' && vr2 != ',' && vr2 != 0 && vr2 != 1 && vr2 != 2 && vr2 != 3 && vr2 != 4 && vr2 != 5 && vr2 != 6 && vr2 != 7 && vr2 != 8 && vr2 != 9){
		    vr = vr.substr(0, tam - 1);
	    }
    	
	    tam = vr.length;

	    if ( tam <= 2 ){ 
		    document.form1.elements[campo].value = vr ; }
	    if ( (tam > 2) && (tam <= 5) ){
		    document.form1.elements[campo].value = vr.substr( 0, tam - 2 ) + ',' + vr.substr( tam - 2, tam ) ; }
	    if ( (tam >= 6) && (tam <= 8) ){
		    document.form1.elements[campo].value = vr.substr( 0, tam - 5 ) + '.' + vr.substr( tam - 5, 3 ) + ',' + vr.substr( tam - 2, tam ) ; }
	    if ( (tam >= 9) && (tam <= 11) ){
		    document.form1.elements[campo].value = vr.substr( 0, tam - 8 ) + '.' + vr.substr( tam - 8, 3 ) + '.' + vr.substr( tam - 5, 3 ) + ',' + vr.substr( tam - 2, tam ) ; }
	    if ( (tam >= 12) && (tam <= 14) ){
		    document.form1.elements[campo].value = vr.substr( 0, tam - 11 ) + '.' + vr.substr( tam - 11, 3 ) + '.' + vr.substr( tam - 8, 3 ) + '.' + vr.substr( tam - 5, 3 ) + ',' + vr.substr( tam - 2, tam ) ; }
	    if ( (tam >= 15) && (tam <= 17) ){
		    document.form1.elements[campo].value = vr.substr( 0, tam - 14 ) + '.' + vr.substr( tam - 14, 3 ) + '.' + vr.substr( tam - 11, 3 ) + '.' + vr.substr( tam - 8, 3 ) + '.' + vr.substr( tam - 5, 3 ) + ',' + vr.substr( tam - 2, tam ) ;}
    }
    
        function Left(str, n){
	    if (n <= 0)
	        return "";
	    else if (n > String(str).length)
	        return str;
	    else
	        return String(str).substring(0,n);
    }

    
    function Right(str, n){
        if (n <= 0)
           return "";
        else if (n > String(str).length)
           return str;
        else {
           var iLen = String(str).length;
           return String(str).substring(iLen, iLen - n);
        }
    }   

    function LTrim( value ) {
    	
	    var re = /\s*((\S+\s*)*)/;
	    return value.replace(re, "$1");
    	
    }


    function RTrim( value ) {
    	
	    var re = /((\s*\S+)*)\s*/;
	    return value.replace(re, "$1");
    	
    }


    function trim( value ) {
    	
	    return LTrim(RTrim(value));
    	
    }