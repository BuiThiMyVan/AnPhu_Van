var isPositionFixed=1;var isMobile=0;$(window).load(function(a){scrollAnimation()});$(window).scroll(function(a){if(!navigator.userAgent.match(/MSIE/i)){changeSubmenuHighlight()}fixedPosition();fixedPositionScroll()});function scrollAnimation(){if(isMobile==0){$("a[href*=#wrap], a[href*=#slide_content01], a[href*=#slide_content02], a[href*=#slide_content03], a[href*=#slide_content04], a[href*=#slide_content05], a[href*=#slide_content06], a[href*=#slide_content07], a[href*=#slide_content08], area[href*=#wrap], area[href*=#slide_content01], area[href*=#slide_content02], area[href*=#slide_content03], area[href*=#slide_content04], area[href*=#slide_content05], area[href*=#slide_content06], area[href*=#slide_content07], area[href*=#slide_content08]").click(function(){alert("a");if(navigator.userAgent.match(/MSIE/i)){initSubmenuHighlight();$(this).addClass("on")}if(location.pathname.replace(/^\//,"")==this.pathname.replace(/^\//,"")&&location.hostname==this.hostname){var a=$(this.hash);a=a.length&&a||jQuery("[name="+this.hash.slice(1)+"]");if(a.length){var b=a.offset().top;jQuery("html,body").animate({scrollTop:b},{duration:500,easing:"motion"});return false}else{return true}}else{return true}})}else{alert("a");$("a[href*=#wrap]").click(function(){goToMyId("wrap")});$("a[href*=#slide_content01]").click(function(){goToMyId("slide_content01")});$("a[href*=#slide_content02]").click(function(){goToMyId("slide_content02")});$("a[href*=#slide_content03]").click(function(){goToMyId("slide_content03")});$("a[href*=#slide_content04]").click(function(){goToMyId("slide_content04")});$("a[href*=#slide_content05]").click(function(){goToMyId("slide_content05")});$("a[href*=#slide_content06]").click(function(){goToMyId("slide_content06")});$("a[href*=#slide_content07]").click(function(){goToMyId("slide_content07")});$("a[href*=#slide_content08]").click(function(){goToMyId("slide_content08")});$("area[href*=#wrap]").click(function(){goToMyId("wrap")});$("area[href*=#slide_content01]").click(function(){goToMyId("slide_content01")});$("area[href*=#slide_content02]").click(function(){goToMyId("slide_content02")});$("area[href*=#slide_content03]").click(function(){goToMyId("slide_content03")});$("area[href*=#slide_content04]").click(function(){goToMyId("slide_content04")});$("area[href*=#slide_content05]").click(function(){goToMyId("slide_content05")});$("area[href*=#slide_content06]").click(function(){goToMyId("slide_content06")});$("area[href*=#slide_content07]").click(function(){goToMyId("slide_content07")});$("area[href*=#slide_content08]").click(function(){goToMyId("slide_content08")});if(!location.hash||location.hash=="#wrap"){setTimeout(scrollTo,0,0,1)}else{if(location.hash=="#slide_content01"){goToMyId("slide_content01")}if(location.hash=="#slide_content02"){goToMyId("slide_content02")}if(location.hash=="#slide_content03"){goToMyId("slide_content03")}if(location.hash=="#slide_content04"){goToMyId("slide_content04")}if(location.hash=="#slide_content05"){goToMyId("slide_content05")}if(location.hash=="#slide_content06"){goToMyId("slide_content06")}if(location.hash=="#slide_content07"){goToMyId("slide_content07")}if(location.hash=="#slide_content08"){goToMyId("slide_content08")}}}}function goToMyId(a){var c=$("div[id="+a+"]");if(c.length){var b=c.offset().top;$("html,body").animate({scrollTop:b},{duration:1000,easing:"motion",complete:function(){fixedPositionScroll();changeSubmenuHighlight()}});return false}}function fixedPosition(){var a=parseInt(($(window).width()-940)/2);if(a<0){a=0}if($(window).scrollTop()>413){if(isPositionFixed==0){$(".wrap .floating_cubemenu").css("position","absolute")}else{$(".wrap .floating_cubemenu").css("position","fixed")}}else{$(".wrap .floating_cubemenu").css("position","absolute")}}function fixedPositionScroll(){var a=parseInt(($(window).width()-940)/2);if(a<0){a=0}if($(window).scrollTop()>=95){if(isPositionFixed==0){$(".wrap .floating_cubemenu").css("top",$(window).scrollTop()-95)}else{$(".wrap .floating_cubemenu").css("top",0)}}else{$(".wrap .floating_cubemenu").css("top",0)}}function initSubmenuHighlight(){for(var a=0;a<$(".submenu a").length;a++){$(".submenu a").eq(a).removeClass("on")}}function changeSubmenuHighlight(){if($("#wrap")||$("#general")){for(var b=0;b<$(".submenu a").length;b++){if($(".submenu a").eq(b).attr("href")!="#"){var a=$(".submenu a").eq(b).attr("href").split("#");try{if($(window).scrollTop()>=$("#"+a[1]).offset().top-10){initSubmenuHighlight();if($(window).scrollTop()>=10){$(".submenu a").eq(b).addClass("on")}}}catch(c){}}}}};