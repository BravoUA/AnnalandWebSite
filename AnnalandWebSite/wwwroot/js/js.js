$( function() {var state = true; $( ".save" ).click(function(){ if ( state ) {$("#Vuros").hide( 1000, function() {$(".slidedown").animate({height:"0px", "opacity":"0"})});$("#Techic").hide( 1000, function() {$(".slidedown").animate({ height:"0px", "opacity":"0"})});$("#Save").css({opacity :"0",display :"block"}).show().animate({ overflow: "hidden",opacity: "1"}, 1000 ); }state = true;});var state = true;$( ".vurosh" ).click(function(){if ( state ) { $("#Save").hide( 1000, function() { $(".slidedown").animate({ height:"0px", "opacity":"0"})}); $("#Techic").hide( 1000, function() {$(".slidedown").animate({ height:"0px","opacity":"0"})});$("#Vuros").css({opacity :"0",display :"block"}).show().animate({overflow: "hidden", opacity: "1"}, 1000 );} state = true; });var state = true;$( ".techic" ).click(function(){ if ( state ) {$("#Save").hide( 1000, function() {$(".slidedown").animate({height:"0px","opacity":"0"})});$("#Vuros").hide( 1000, function() {$(".slidedown").animate({height:"0px","opacity":"0"})});$("#Techic").css({opacity :"0",display :"block"}).show().animate({overflow: "hidden",opacity: "1"}, 1000 );}state = true;});} );$( function() {var state = true;$( ".botplus" ).click(function(){if ( state ) {$(".slidedown").css({opacity :"0",display :"table",width: "1000px"}).show().animate({overflow: "hidden",opacity: "1"}, 1000 );} else {$(".slidedown").hide( 1000, function() {$(".slidedown").animate({height:"0px","opacity":"0"})});}state = !state;});} );$( function() {var state = true;$( ".botplus2" ).click(function(){if ( state ) {$(".slidedown2").css({"opacity":"0","display":"table",width: "1000px"}).show().animate({opacity: "1"}, 1000 );} else {$(".slidedown2").css({"opacity":"0"}).animate({opacity: "0"}, 1000 ).hide();}state = !state;});} );$( function() {var state = true;$( ".bay" ).click(function(){if ( state ) {$(".SendM").css({"opacity":"0","display":"block"}).show().animate({opacity: "1","display":"block"}, 1000 );}state = !state;});} );






