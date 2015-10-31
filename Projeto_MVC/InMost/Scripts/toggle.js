$(window).load(function(){

	$(".btn-aceita").click(function(){		
		var id = $(this).attr("data-id");
		$(this).addClass("icon-hover");
		$(".btn-rejeita").removeClass("icon-hover");
	    $(".int-"+id).slideToggle("slow");	    
	    $(".int-"+id).find(input).removeAttr('disabled');
	});

	$(".btn-rejeita").click(function(){
		var id = $(this).attr("data-id");
		$(this).addClass("icon-hover");
		$(".btn-aceita").removeClass("icon-hover");
		$(".int-"+id).hide("slow");
	    $(".int-"+id).find(input).attr('disabled','disabled');
	    $(".int-"+id).find(input).removeAttr('checked');
	});

});