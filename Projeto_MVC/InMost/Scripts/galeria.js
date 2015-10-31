$(window).load(function(){

	$(".foto-edit").click(function(){		
		var id = $(this).attr("data-id");
		$(".rmv-foto-"+id).slideToggle("slow");
	});
	$(".remove-foto").click(function(){
		var id = $(this).attr("data-id");
		$(".rmv-foto-"+id).slideToggle("slow");
	});

});