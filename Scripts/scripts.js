"use strict";

// Login effect
$('.user-btn-toggle').on( 'click', function() {
	$('.login-form-wrap').fadeIn(300);
});

$('.user-close-toggle').on( 'click', function() {	
	$('#user-form').fadeOut(300);
});

/* aside menu dropdowns */
$('.aside-menu-item.has-submenu a').on('click',function(){
	$(this).parent().toggleClass('active');
	$(this).parent().children('.aside-submenu').slideToggle(300);
});

/* aside menu dropdowns */
$('.sidemenu-item.has-dropdown a').on('click',function(){
	$(this).parent().toggleClass('active');
	$(this).parent().children('.side-submenu').slideToggle(300);
});

/* aside-toggler */
$('.btn-menu-toggle').on('click',function(){
	$('body').toggleClass('overflowed');
	$('#aside').toggleClass('rails-girls');
	$('#main-section').toggleClass('rails-girls');
});

/* full height carousel */
$('.carousel-inner .item').height($(window).height()-90);

// Fancybox
$(".gallery-items").fancybox({
	'titlePosition' 	: 'over',
	'cyclic'			: true,
	'titleFormat'		: function(title, currentArray, currentIndex, currentOpts) {
		return '<span id="fancybox-title-over">'+ (title.length ? ' &nbsp; <h3>' + title : '</h3>')  + '<p> სურათი ' +(currentIndex + 1) + ' / ' + currentArray.length +'</p>'+ '</span>';
	}
});