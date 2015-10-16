$(window).load(function(){
	$(".btn-menu").click(function () {
	    $("#menu-toggle").toggle("slide");
	    $('#main').css('width', '75%');
	});
});
