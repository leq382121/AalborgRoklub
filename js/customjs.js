$("#menu-toggle").on('click', function(e) {
    e.preventDefault();
    $("#wrapper").toggleClass("toggled");
    $("#menu-toggle > i").toggleClass('fa-bars fa-2x fa-times fa-2x');
});



//$('.sidebar-button').click(function() {
//   var collapsed = $(this).find('i').hasClass('fa-bars');

//    $('.sidebar-button').find('i').removeClass('fa-times');

//  $('.sidebar-button').find('i').addClass('fa-bars');
// if (collapsed)
//   $(this).find('i').toggleClass('fa-bars fa-2x fa-times fa-2x')
//});