// JavaScript Document

var didscroll=false;
	window.onscroll=function(){
		if(window.pageYOffset>150 && didscroll==false){
		document.getElementById("header").classList.add("fixed");
			document.getElementById("logo2").style.display="block";
            	document.getElementById("caption").style.display="none";

			
	 setTimeout(lock,300);
		}
		
		else if(window.pageYOffset<150 ){
		document.getElementById("header").classList.remove("fixed");
			
			document.getElementById("logo2").style.display="none";
             	document.getElementById("caption").style.display="block";

			didscroll=false;
			
		}
	};
	
	function lock(){if(didscroll==true)didscroll=false;else didscroll=true;};


var active=0;
$(document).ready(function()
				  {
	
	var interval = setInterval(slide,2000);
	
	$('.slide').each(function(){$('.pages').append('<span/>');});
	
});

	
	function slide()
	{
			var l=$('.slide').length;
		
			$('.slide').css('opacity','0');
		$('.pages span').css('opacity','0.3');
		
	$('.pages span:eq('+active%l+')').css('opacity','1');
		$('.slide:eq('+active%l+')').css('opacity','1');
		active++;
		
	}





