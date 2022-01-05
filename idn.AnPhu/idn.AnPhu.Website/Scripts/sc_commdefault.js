/* motion */
jQuery.easing.motion = function (x, t, b, c, d) {if (t==0) return b;if (t==d) return b+c;if ((t/=d/2) < 1) return c/2 * Math.pow(2, 10 * (t - 1)) + b;return c/2 * (-Math.pow(2, -10 * --t) + 2) + b;}

/* current OS */
var isPositionFixed=1; // IE6과 모바일 iOS에서 포지션 Fixed 값 무시됨.
var isMobile=0; // 스마트폰인경우
var isIE6=0; // 웹브라우저 ie6인 경우
if (navigator.userAgent.match(/BlackBerry/i) || navigator.userAgent.match(/Android/i) || navigator.userAgent.match(/Windows CE/i) || navigator.userAgent.match(/Symbian/i) || navigator.userAgent.match(/webOS/i) || navigator.userAgent.match(/iPhone/i) || navigator.userAgent.match(/iPod/i) || navigator.userAgent.match(/iPad/i)) isMobile=1;
if (navigator.userAgent.match(/Android 1.5/i) || navigator.userAgent.match(/Android 2.1/i) || navigator.userAgent.match(/iPhone/i) || navigator.userAgent.match(/iPod/i) || navigator.userAgent.match(/iPad/i)) isPositionFixed=0;
if (navigator.userAgent.match(/MSIE 6.0/i)) {isIE6=1;isPositionFixed=0;}
function isTouchDevice(){try{document.createEvent("TouchEvent");return true;}catch(e){return false;}}
function touchScroll(id){
	if(isTouchDevice()){ //if touch events exist...
		if (document.getElementById(id)) {
			var el=document.getElementById(id);
			var scrollStartPos=0;
			document.getElementById(id).addEventListener("touchstart", function(event) {
				scrollStartPos=this.scrollTop+event.touches[0].pageY;
				event.preventDefault();
			},false);
			document.getElementById(id).addEventListener("touchmove", function(event) {
				this.scrollTop=scrollStartPos-event.touches[0].pageY;
				event.preventDefault();
			},false);
		}
	}
}
function TrimString( strVal ) {
	if( strVal.split(" ").join("") == "" ) return false;
	else return true;
}
// document ready
$(document).ready(function() {
	//readyCube();
	fixedPosition();
	if (!location.hash || location.hash=="#pip" || isMobile==0) fixedPositionScroll();
	//if (document.getElementById("cubebox")) {
	//	cubeMotionInit();
	//	if (cubeList.length>0) {
	//		$(".floating_cubemenu .cubemenu .information").css("width",619 + (5-cubeList.length)*70);
	//		$(".floating_cubemenu .cubemenu ul.cubeitem").css("width",282 - (5-cubeList.length)*70);
	//	}
	//}


	//if (document.getElementById("main")) {
	//	var t = parseInt((940 - $(".carlist ul").width())/2);
	//	$(".carlist").css("width",940-t).css("paddingLeft",t);
	//}
	//$(".mainbanner .banners .item a img").mouseover(function() {$(this).animate({opacity: '.4'}, 100, function(){$(this).animate({opacity: '1'}, 300);});});

	//$('#slider_deposit').bind("mouseup",function() {
	//	var deposit = $('#slider_deposit .jslider-value span').text();
	//	var Price = $('.con_price .price').text();
	//	var v_num = /[^0-9]/g;
	//	var c_num = Price.replace(v_num,'');
	//	var d_price = (c_num*deposit)/100
	//	$('#deposit_price').val(d_price.toLocaleString());
	//});
	//$('#slider_month').bind("mouseup",function() {
	//	var changeMonth = $('#slider_month .jslider-value span').text();
	//	$('.change_month').text(changeMonth);
	//});

	//$('.tips_advice .show_btn .expand').click(function(){$('.tips_advice .tips_wrap').addClass('on');$('.tips_advice .show_btn').addClass('off');$(".show_btn .expand").hide();$(".show_btn .collapse").show();return false;});
	//$('.tips_advice .show_btn .collapse').click(function(){$('.tips_advice .tips_wrap').removeClass('on');$('.tips_advice .show_btn').removeClass('off');$(".show_btn .expand").show();$(".show_btn .collapse").hide();return false;});
	//$('.tips_advice .tips').click(function(){$(this).parent().toggleClass('on');});
	//$('.faq .show_btn .expand').click(function(){$('.faq .qna').addClass('on');$(".show_btn .expand").hide();$(".show_btn .collapse").show();return false;});
	//$('.faq .show_btn .collapse').click(function(){$('.faq .qna').removeClass('on');$(".show_btn .expand").show();$(".show_btn .collapse").hide();return false;});
	//$('.car_compare .show_btn .expand').click(function(){$('.car_compare .con_table').addClass('on');$('.con_table .show_btn').addClass('off');$(".show_btn .expand").hide();$(".show_btn .collapse").show();return false;});
	//$('.car_compare .show_btn .collapse').click(function(){$('.car_compare .con_table').removeClass('on');$('.car_compare .show_btn').removeClass('off');$(".show_btn .expand").show();$(".show_btn .collapse").hide();return false;});
	//$('.car_compare .title').click(function(){$(this).parent().toggleClass('on');});

	//$(".form_table input:text").click(function() {
	//	var nowV = $(this).val();
	//	var defV = this.defaultValue;
	//	if(nowV == defV) { $(this).val("");}
	//});
	//$(".form_table textarea").click(function() {
	//	var nowV = $(this).val();
	//	var defV = this.defaultValue;
	//	if(nowV == defV) { $(this).val("");}
	//});
	//$('.faq .q').click(function(){$(this).parent().toggleClass('on');});
	//$(".cubebox .cubelist .talkntalk_form form .input textarea").bind("focus",function() {
	//	$(".cubebox .cubelist .talkntalk_form form .input").css("height",152).css("width",232).css("borderLeft","1px solid #aaaaac").css("borderRight","1px solid #aaaaac").css("borderBottom","1px solid #aaaaac").css("marginRight","2px");
	//	$(".cubebox .cubelist .talkntalk_form form .input div textarea").css("height",150).css("borderBottom","1px solid #d2d3d4");
	//});
	//$(".cubebox .cubelist .talkntalk_form form .input textarea").bind("blur",function() {
	//	$(".cubebox .cubelist .talkntalk_form form .input").css("height",26).css("width",231).css("borderLeft","1px solid #ffffff").css("borderRight","1px solid #ffffff").css("borderBottom",0).css("marginRight","3px");
	//	$(".cubebox .cubelist .talkntalk_form form .input div textarea").css("height","100%").css("borderBottom",0);
	//});
	//$(".cubebox .cubelist .experience_seemore .button a").click(function() {var w = parseInt(($(window).width()-600)/2);$(".layer_experience").css("left",w).fadeIn();});
	//$(".layer_experience .layer_close a").click(function() {$(".layer_experience").fadeOut();});
	//$(".open_layer").click(function() {showTranslucency();$("#layer_popup").css("top",(parseInt($(window).scrollTop())+50) + "px");$("#layer_popup").show();});

	///* CB_popup input del icon */
	//$('input.#deposit_price').wrap('<span class="deleteicon" />').after($('<span/>').click(function() {
	//	$(this).prev('input').val('').focus();
	//}));

	///* close layer */
	//$("#layer_myplace .close_layer").click(function() {hideTranslucency();$("#layer_myplace").hide();});
	//$("#layer_popup .close_layer").click(function() {hideTranslucency();$("#layer_popup").hide();});
	//$("#layer_cb01 .close_layer").click(function() {hideTranslucency();$("#layer_cb01").hide();});
	//$("#layer_cb02 .close_layer").click(function() {hideTranslucency();$("#layer_cb02").hide();});
	//$("#layer_cb03 .close_layer").click(function() {hideTranslucency();$("#layer_cb03").hide();});
	//$("#layer_cb04 .close_layer").click(function() {hideTranslucency();$("#layer_cb04").hide();});
	//$("#layer_cb05 .close_layer").click(function() {hideTranslucency();$("#layer_cb05").hide();});
	//$("#layer_cb06 .close_layer").click(function() {hideTranslucency();$("#layer_cb06").hide();});
	//$("#layer_cb07 .close_layer").click(function() {hideTranslucency();$("#layer_cb07").hide();});
	//$("#layer_cb08 .close_layer").click(function() {hideTranslucency();$("#layer_cb08").hide();});
	//$("#layer_cb09 .close_layer").click(function() {hideTranslucency();$("#layer_cb09").hide();});
	//$("#layer_cb10 .close_layer").click(function() {hideTranslucency();$("#layer_cb10").hide();});
	//$("#layer_cb11 .close_layer").click(function() {hideTranslucency();$("#layer_cb11").hide();});
	//$("#layer_pagenotfound .close_layer").click(function() {hideTranslucency();$("#layer_pagenotfound").hide();});
	//$("#compare_popup01 .close_layer").click(function() {hideTranslucency();$("#compare_popup01").hide();});
	//$("#compare_popup02 .close_layer").click(function() {hideTranslucency();$("#compare_popup02").hide();});
	//$("#package_compare .con_popup .close_layer").click(function() {hideTranslucency();$("#package_compare").hide();});
	//$("#compare_car .con_popup .close_layer").click(function() {hideTranslucency();$("#compare_car").hide();});
	//$("#compare_option .con_popup .close_layer").click(function() {hideTranslucency();$("#compare_option").hide();});
	//$("#code_popup .close_layer").click(function() {hideTranslucency();$("#code_popup").hide();});
	//$("#rebuild_pop .close_layer").click(function() {hideTranslucency();$("#rebuild_pop").hide();});
	//$("#layer_over140 .close_layer").click(function() {hideTranslucency();$("#layer_over140").hide();});

	//$(".ads_list .con_ads li").click(function() {
	//	var h=$(document).height()
	//	$('#layer_popup.play_movie').css("height",h);
	//	$("#layer_popup").show();
	//	$(".thum_list .car_list").jCarouselLite({btnNext: ".thum_list .arrow_right",btnPrev: ".thum_list .arrow_left",scroll: 1,visible: 4,circular: false});
	//});
	//$(".car_photo .car_list_sort ul li").css("width","198px");
	//$(".car_photo .car_list_sort ul li").css("height","130px");
	//var liSize = $(".car_photo .car_list_sort ul li").size();
	//var ulWidth = liSize * 198;
	//$(".car_photo .car_list_sort ul").css("width", ulWidth);
	//	$('.gnb>li>a').click(function(){
	//	var currentTab=$(this).attr('href');
	//	if($(this).hasClass('on')){
	//		$(this).removeClass('on');
	//		$(currentTab).hide();
	//		return false;
	//	} else {
	//		$('.gnb>li>a').removeClass('on');
	//		$('.gnb_layer').hide();
	//		$(this).addClass('on');
	//		$(currentTab).show();
	//		return false;
	//	}
	//});
	//$('.gnb_layer .showroom .tab ul a').click(function(){
	//	var currentTab=$(this).attr('href');
	//	$('.gnb_layer .showroom .tab a').removeClass('on');
	//	$('.gnb_layer .showroom>.list ul').hide();
	//	$('.gnb_layer .showroom .carfinder').hide();
	//	$(this).addClass('on');
	//	$(currentTab).show();
	//	$('.gnb_layer .showroom .banners').show();
	//	return false;
	//});
	//$('.gnb_layer .showroom .tab .btn_finder').click(function(){
	//	$('.gnb_layer .showroom .tab a').removeClass('on');
	//	$('.gnb_layer .showroom>.list ul').hide();
	//	$('.gnb_layer .showroom .banners').hide();
	//	$(this).addClass('on');
	//	$('.gnb_layer .showroom .carfinder').show();
	//	return false;
	//});
	//$('.gnb_layer .btn_close').click(function(){$('.gnb_layer').hide();$('.gnb li a').removeClass('on');});
	//$('.gnb_layer .carfinder .category li .jqTransformCheckbox').click(function(){
	//	if($(this).parent().parent().hasClass('select'))
	//		$(this).parent().parent().removeClass('select');
	//	else
	//		$(this).parent().parent().addClass('select');
	//});
	//$('.gnb_layer .category .case2 span:not(".unable"),.gnb_layer .category .case3 span:not(".unable"),.gnb_layer .configuration span:not(".unable"),.gnb_layer .seats .case2 span:not(".unable"),.gnb_layer .seats .case3 span:not(".unable"),.gnb_layer .fueltype span:not(".unable")').toggle(function(){$(this).addClass('select');},function(){$(this).removeClass('select');});

	///* car bulder option select button */
	//$('.car_builder .options_lists .btn').toggle(function(){$(this).addClass('selected');return false;},function(){$(this).removeClass('selected');return false;});
	//$('.main_gallery .photo').cycle({fx:     'fade',speed:  'slow',timeout: 0,
	//	pager:  '.car_list .car_list_sort ul',
	//	pagerAnchorBuilder: function(idx, slide) {
	//		return '.car_list .car_list_sort ul li:eq(' + idx + ')';
	//	}
	//});
	//$(".car_list .car_list_sort").jCarouselLite({btnNext: ".car_list .list_next",btnPrev: ".car_list .list_prev",scroll: 1,visible: 4,circular: false});
	////$(".car_list .car_list_sort ul li").hover(function(){$(this).addClass('selected');return false;},function(){$(this).removeClass('selected');return false;});
	//$('.car_select_list li').hover(function(){
	//	$(this).find('.thumb').css('background','url(/wcm/images/es/function/txt_item_select_l.gif) no-repeat 0 87px');
	//	$(this).find('a').css('color','#0a2268');
	//	$(this).find('.thumb').animate({
	//		marginTop:'-18px',
	//		paddingBottom:'18px'
	//	},400);
	//},function(){
	//	$(this).find('a').css('color','#333333');
	//	$(this).find('.thumb').animate({
	//		marginTop:0,
	//		paddingBottom:0
	//	},{duration:200,complete:function() {
	//		$(this).css('background','none');
	//	}});
	//});
	//$('.car_selectlist li').hover(function(){
	//	$(this).addClass('select');
	//	$(this).find('.thumb').css('background','transparent url(/wcm/images/common/function/bg_carlist_select_on.png) no-repeat 0 65px');
	//	$(this).find('.thumb').animate({
	//		marginTop:'-13px',
	//		paddingBottom:'13px'
	//	},400);
	//},function(){
	//	$(this).removeClass('select');
	//	$(this).find('.thumb').animate({
	//		marginTop:'0',
	//		paddingBottom:'0'
	//	},{duration:100,complete:function() {
	//		$(this).css('backgroundImage','none');
	//	}});
	//});
	//// scroll for smart phone // overflow:auto;
	//if (isMobile==1) {
	//	$(".dealerfinder_direction .direction .direction_result").css("height","auto");
	//	$(".cb_img_table .con_explain").css("height","auto");
	//	touchScroll('accessory_scroll');
	//	touchScroll('facebook_scroll');
	//	touchScroll('twitter_scroll');
	//	touchScroll('exterior_scroll');
	//	touchScroll('interior_scroll');
	//	touchScroll('trim1_scroll');
	//	touchScroll('trim2_scroll');
	//	touchScroll('etc_scroll');
	//	touchScroll('content_package');
	//	touchScroll('group_explain');
	//}
	///* scripts for spec */
	//$(".expand_contract a.plus").click(function() {
	//	// open all
	//	$(".expand_contract a.plus").hide();
	//	$(".expand_contract a.minus").show();
	//	$(".slide_content_last .spec_performance .spec_table").css("height","auto");
	//	$(".slide_content_last .spec_dimemsion .spec_table").css("height","auto");
	//	$(".slide_content_last .spec_chassis .spec_table").css("height","auto");
	//	$(".slide_content_last .spec_dhassis .spec_table").css("height","auto");
	//	$(".slide_content_last .spec_performance .spec_performance_title a").addClass("on");
	//	$(".slide_content_last .spec_dimemsion .spec_dimemsion_title a").addClass("on");
	//	$(".slide_content_last .spec_chassis .spec_chassis_title a").addClass("on");
	//	$(".slide_content_last .spec_dhassis .spec_dhassis_title a").addClass("on");
	//	return false;
	//});
	//$(".expand_contract a.minus").click(function() {
	//	// close all
	//	$(".expand_contract a.plus").show();
	//	$(".expand_contract a.minus").hide();
	//	$(".slide_content_last .spec_performance .spec_table").css("height","1px");
	//	$(".slide_content_last .spec_dimemsion .spec_table").css("height","1px");
	//	$(".slide_content_last .spec_chassis .spec_table").css("height","1px");
	//	$(".slide_content_last .spec_dhassis .spec_table").css("height","1px");
	//	$(".slide_content_last .spec_performance .spec_performance_title a").removeClass("on");
	//	$(".slide_content_last .spec_dimemsion .spec_dimemsion_title a").removeClass("on");
	//	$(".contents_specification .spec_chassis .spec_chassis_title a").removeClass("on");
	//	$(".contents_specification .spec_dhassis .spec_dhassis_title a").removeClass("on");
	//	return false;
	//});
	//$(".slide_content_last .spec_performance .spec_performance_title a").click(function() {toggleSpecItem("performance");return false;});
	//$(".slide_content_last .spec_dimemsion .spec_dimemsion_title a").click(function() {toggleSpecItem("dimemsion");return false;});
	//$(".slide_content_last .spec_chassis .spec_chassis_title a").click(function() {toggleSpecItem("chassis");return false;});
	//$(".slide_content_last .spec_dhassis .spec_dhassis_title a").click(function() {toggleSpecItem("dhassis");return false;});

	//if (document.getElementById("floating_top")) {floating_top();}
});

$(window).load(function(e){
	scrollAnimation();
});
/* resize event */
$(window).resize(function(e){
	if (isMobile==0) {fixedPosition();galleryPopup();}
	if($(".layer_experience_panorama .large .panorama img").is("img.panorama_large")) {
		var w=$(".layer_experience_panorama .large .panorama img.panorama_large").width();
		var h=$(".layer_experience_panorama .large .panorama img.panorama_large").height();
		$(".layer_experience_panorama .large .panorama").css("width",$(window).width()).css("height",parseInt($(window).width()*h/w));
		$(".layer_experience_panorama .large .panorama img.panorama_large").css("width",$(window).width()).css("height",parseInt($(window).width()*h/w));
		$(".pano_loading_percent").css("left",parseInt($(".layer_experience_panorama .large .panorama").width()/2-55) + 'px').css("top",parseInt($(".layer_experience_panorama .large .panorama").height()/2-50) + 'px');
		$(".pano_loading_start").css("left",parseInt($(".layer_experience_panorama .large .panorama").width()/2-55) + 'px').css("top",parseInt($(".layer_experience_panorama .large .panorama").height()/2-50) + 'px');
	}
	if (document.getElementById("floating_top")) {floating_top();}
});
/* scroll event */
$(window).scroll(function(e){
///	if (!navigator.userAgent.match(/MSIE/i)) {changeSubmenuHighlight();}
	fixedPosition();fixedPositionScroll();
});
/* mousemove event
$(document).mousemove(function(e){
	if(!document.getElementById('gnb')) return false;
	var x = e.pageX;
	var y = e.pageY;
	var w = $(window).width();
	var h = $(window).height();
	var gnbLeft = $('.gnb').position().left;
	var gnbTop = $('.gnb').position().top;
	if(x<gnbLeft || x > gnbLeft+$('.header').width() || y<gnbTop || y>gnbTop+$('.gnb_layer:visible').height()){
		$('.wrap').click(function(){
			$('.gnb>li>a').removeClass('on');
			$('.gnb_layer').hide();
		});
	} else {
		return false;
	}
}); */

/* ********** functions ********** */
//function floating_top() {
//	var leftvalue = ($(window).width()-960)/2 + 960;
//	$("#floating_top").css("left",leftvalue);
//}
//function chkInput(obj) {
//	var nowV = obj.val();
//	var defV = obj[0].defaultValue;
//	if(nowV == defV || !TrimString(nowV)) {
//		obj.parent().parent().addClass("check");
//		return 0;
//	} else {
//		obj.parent().parent().removeClass("check");
//		return 1;
//	}
//}
//function chkSelect(obj) {
//	var nowV = obj.val();
//	if(nowV == "") {
//		obj.parent().parent().parent().addClass("check");
//		return 0;
//	} else {
//		obj.parent().parent().parent().removeClass("check");
//		return 1;
//	}
//}
//function toggleSpecItem(va) {
//	var cl = $(".slide_content_last .spec_"+va+" .spec_table").css("height");
//	if (cl==1 || cl=="1" || cl=="1px") {
//		// open
//		$(".slide_content_last .spec_"+va+" .spec_table").css("height","auto");
//		$(".slide_content_last .spec_"+va+" .spec_"+va+"_title a").addClass("on");
//	} else {
//		// close
//		$(".slide_content_last .spec_"+va+" .spec_table").css("height","1px");
//		$(".slide_content_last .spec_"+va+" .spec_"+va+"_title a").removeClass("on");
//	}
//}
//function cubeTalknTalkInit() {
//	$(".cubebox .cubelist .talkntalk_list ul li .comment").each(function() {$(this).empty();});
//	$(".cubebox .cubelist .talkntalk_list ul li .name").each(function() {$(this).empty();});
//}
//function cubeTalknTalk(num,socialType,profileImg,name,txt) {
//	$(".cubebox .cubelist .talkntalk_list ul li.comment"+num+" .name").append('<img src="/wcm/images/common/icon/icon_cube_talkntalk_'+socialType+'.gif" alt="" /><img src="'+profileImg+'" alt="" class="profile" /> <span>'+name+'</span>');
//	$(".cubebox .cubelist .talkntalk_list ul li.comment"+num+" .comment").txtloopit('"'+txt+'"');
//}
//function cubeMostLikeCate(selectNum, profile1, profile2, profile3, name1, name2, name3) {
//	$(".mostlike_best3").empty();
//	$(".mostlike_best3").append("<ul></ul>");
//	if (selectNum==1) {
//		$(".mostlike_best3 ul").append('<li class="best1 on"><a href="#"><img src="'+profile1+'" alt="" /><strong>'+name1+'\'s</strong><br />Chosen</a></li>');
//		$(".mostlike_best3 ul").append('<li class="best2"><a href="#"><img src="'+profile2+'" alt="" /><strong>'+name2+'\'s</strong><br />Chosen</a></li>');
//		$(".mostlike_best3 ul").append('<li class="best3"><a href="#"><img src="'+profile3+'" alt="" /><strong>'+name3+'\'s</strong><br />Chosen</a></li>');
//	} else if (selectNum==2) {
//		$(".mostlike_best3 ul").append('<li class="best1"><a href="#"><img src="'+profile1+'" alt="" /><strong>'+name1+'\'s</strong><br />Chosen</a></li>');
//		$(".mostlike_best3 ul").append('<li class="best2 on"><a href="#"><img src="'+profile2+'" alt="" /><strong>'+name2+'\'s</strong><br />Chosen</a></li>');
//		$(".mostlike_best3 ul").append('<li class="best3"><a href="#"><img src="'+profile3+'" alt="" /><strong>'+name3+'\'s</strong><br />Chosen</a></li>');
//	} else {
//		$(".mostlike_best3 ul").append('<li class="best1 on"><a href="#"><img src="'+profile1+'" alt="" /><strong>'+name1+'\'s</strong><br />Chosen</a></li>');
//		$(".mostlike_best3 ul").append('<li class="best2"><a href="#"><img src="'+profile2+'" alt="" /><strong>'+name2+'\'s</strong><br />Chosen</a></li>');
//		$(".mostlike_best3 ul").append('<li class="best3"><a href="#"><img src="'+profile3+'" alt="" /><strong>'+name3+'\'s</strong><br />Chosen</a></li>');
//	}
//}
//function cubeMostLike(carName,trim,exteriorColor,interiorColor,carImg,seemoreLink,carbuilderLink,likeCode) {
//	$(".mostlike_option .carname").empty();
//	$(".mostlike_option .option").empty();
//	$(".mostlike_option .car_image").empty();
//	$(".mostlike_option .button").empty();
//	$(".mostlike_option .like").empty();
//	$(".mostlike_option .carname").append('<strong>'+carName+'</strong><br />'+trim);
//	$(".mostlike_option .option").append('<img src="/wcm/images/es/cube/mostlike_exteriorcolor.png" alt="Exterior Color" class="option_title" /> <img src="'+exteriorColor+'" alt="" /> <img src="/wcm/images/es/cube/mostlike_interiorcovering.png" alt="Interior Color" class="option_title" /> <img src="'+interiorColor+'" alt="" />');
//	$(".mostlike_option .car_image").append('<img src="'+carImg+'" alt="" /><br />');
//	$(".mostlike_option .button").append('<a href="'+seemoreLink+'"><img src="/wcm/images/es/btn/btn_seemore.gif" alt="see more" /></a>');
//	$(".mostlike_option .button").append('<a href="'+carbuilderLink+'"><img src="/wcm/images/es/btn/btn_carbuilder.gif" alt="Build your own" /></a>');
//	$(".mostlike_option .like").append(likeCode);
//}
//function cubeExperience(cate,panoramaImg,largeImg,isColor) {
//	var orig_src = "";
//	if (isColor=="color") orig_src = $(".experience_panoramabox img").attr("src");
//	else orig_src = panoramaImg;
//	$(".experience_category").empty();
//	$(".experience_panoramabox").empty();
//	$(".experience_large").empty();
//	$(".experience_option").empty();
//	var src_prefix = panoramaImg.substr(0, orig_src.lastIndexOf('_')+1);
//	var src_sufix = panoramaImg.substr(orig_src.indexOf(src_number,0)+String(src_number).length);
//	var src_number = parseInt(orig_src.substr(orig_src.lastIndexOf('_')+1));
//	if (cate=="exterior") {
//		$(".experience_category").append('<ul><li><a href="#" class="on">Exterior</a></li><li><a href="#">Interior</a></li></ul>');
//		$(".experience_panoramabox.exterior").show();
//		$(".experience_panoramabox.interior").hide();
//		$(".experience_panoramabox.exterior").append('<img src="'+panoramaImg+'" class="panorama" width="640" height="289" alt="" /><br />');
//		$(".exterior img.panorama").panorama({views_number: 36,views_columns: 36});
//		$(".experience_large").append('<a href="#" onclick="showPanoramaLargeLayer(\''+largeImg+'\', \'exterior\');return false;"><img src="/wcm/images/common/btn/btn_largeimg.png" alt="+" /></a><br />');
//		$(".experience_option").append("<ul></ul>");
//		$(".cube_shadow_interior").hide();
//	} else {
//		$(".experience_category").append('<ul><li><a href="#">Exterior</a></li><li><a href="#" class="on">Interior</a></li></ul>');
//		$(".experience_panoramabox.exterior").hide();
//		$(".experience_panoramabox.interior").show();
//		$(".experience_panoramabox.interior").append('<img src="'+panoramaImg+'" class="panorama" width="640" height="251" alt="" /><br />');
//		$(".interior img.panorama").panorama();
//		$(".experience_large").append('<a href="#" onclick="showPanoramaLargeLayer(\''+largeImg+'\', \'interior\');return false;"><img src="/wcm/images/common/btn/btn_largeimg.png" alt="+" /></a><br />');
//		$(".experience_option").append("<ul></ul>");
//		$(".cube_shadow_interior").show();
//	}
//}
//function cubeExperienceColorList(num,onoff,colorImg) {
//	if (onoff=="on") {
//		$(".experience_option ul").append('<li class="color'+num+'"><a href="#"><img src="'+colorImg+'" alt="" /></a><br /><span><img src="/wcm/images/common/bg/cover_color.png" alt="" /></span></li>');
//	} else {
//		$(".experience_option ul").append('<li class="color'+num+'"><a href="#"><img src="'+colorImg+'" alt="" /></a></li>');
//	}
//}
//function showPanoramaLargeLayer(imgurl,mode) {
//	$(".layer_experience_panorama").empty();
//	$(".layer_experience_panorama").append('<div class="layer_panorama_close"><a href="#"><img src="/wcm/images/common/btn/btn_layer_close.png" alt="close" /></a><br /></div>');
//	$(".layer_experience_panorama .layer_panorama_close a").click(function(){fadeinout('.layer_experience_panorama','fadeout');return false;});
//	if (mode=="exterior") {
//		$(".layer_experience_panorama").append('<div class="normal"><div class="box"><img src="'+imgurl+'" width="1024" height="462" class="panorama_large" alt="" /></div></div>');
//		if (document.getElementById("pip") || document.getElementById("main")) {
//			$(".layer_experience_panorama").append('<div class="experience_category"><ul><li><a href="#" class="on">Exterior</a></li><li><a href="#">Interior</a></li></ul></div>');
//		}
//		$("img.panorama_large").panorama({views_number: 36,views_columns: 36});
//	} else {
//		$(".layer_experience_panorama").append('<div class="large"><img src="'+imgurl+'" width="1024" height="590" class="panorama_large" alt="" /></div>');
//		$(".layer_experience_panorama").append('<div class="experience_category"><ul><li><a href="#">Exterior</a></li><li><a href="#" class="on">Interior</a></li></ul></div>');
//		$("img.panorama_large").attr("width",$(window).width());
//		$("img.panorama_large").attr("height",parseInt($(window).width()*590/1024));
//		$("img.panorama_large").panorama();
//	}
//	$(".layer_experience_panorama").append('<div class="experience_desc"><span>The image may differ from the actual product.</span></div>');
//	fadeinout('.layer_experience_panorama','fadein');
//}
//function cubeGalleryLayout(ob,cate) {
//	var obj = ob;
//	obj.empty();
//	if (cate=="all") obj.append('<div class="gallery_category"><ul><li class="on"><a href="#">All</a></li><li><a href="#">Exterior</a></li><li><a href="#">Interior</a></li><li><a href="#">Movies</a></li></ul></div>');
//	else if (cate=="exterior") obj.append('<div class="gallery_category"><ul><li><a href="#">All</a></li><li><a href="#" class="on">Exterior</a></li><li><a href="#">Interior</a></li><li><a href="#">Movies</a></li></ul></div>');
//	else if (cate=="interior") obj.append('<div class="gallery_category"><ul><li><a href="#">All</a></li><li><a href="#">Exterior</a></li><li><a href="#" class="on">Interior</a></li><li><a href="#">Movies</a></li></ul></div>');
//	else obj.append('<div class="gallery_category"><ul><li><a href="#">All</a></li><li><a href="#">Exterior</a></li><li><a href="#">Interior</a></li><li><a href="#" class="on">Movies</a></li></ul></div>');
//	obj.append('<ul class="gallerylist"></ul>');
//	obj.append('<div class="cube_shadow"><div><img src="/wcm/images/common/bg/bg_cube_shadow.png" alt="" /></div></div>');
//}
//function cubeGalleryList(cate,listImg,largeImg,titletxt,titleimg,description,mode,download,twitter,facebook,stumbleupon,like) {
//	$(".gallerylist").append('<li><a href="#" class="'+cate+'" onclick="showGalleryLargeLayer(\''+largeImg+'\',\''+titletxt+'\',\''+titleimg+'\',\''+description+'\',\''+mode+'\',\''+download+'\',\''+twitter+'\',\''+facebook+'\',\''+stumbleupon+'\',\''+like+'\', \'\');return false;"><img src="'+listImg+'" alt="" /></a></li>');
//}
//function cubeGalleryPaging(current,all) {
//	if (current==1) $(".gallerylist").append('<li class="paging"><strong>'+current+'</strong> of '+all+'</a><a href="#" class="next">next</a></li>');
//	else if(current==all) $(".gallerylist").append('<li class="paging"><a href="#" class="prev">previous</a><strong>'+current+'</strong> of '+all+'</a></li>');
//	else $(".gallerylist").append('<li class="paging"><a href="#" class="prev">previous</a><strong>'+current+'</strong> of '+all+'</a><a href="#" class="next">next</a></li>');
//}
//function showGalleryLargeLayer(code,carname,titleimg,description,isImg,download,twitter,facebook,stumbleupon,like,isMain) {
//	$(".layer_gallery").empty();
//	$(".layer_gallery").append('<div class="layer_gallery_close"><a href="#"><img src="/wcm/images/common/btn/btn_layer_close2.png" alt="close" /></a><br /></div>');
//	$(".layer_gallery .layer_gallery_close a").click(function() {fadeinout('.layer_gallery','fadeout');galleryPopup();$(".layer_gallery").empty();return false;});
//	$(".layer_gallery").append('<div class="layer_gallery_title"><img src="'+titleimg+'" alt="'+carname+'" /> '+description+'</div>');
//	if (isImg=="image") {
//		$(".layer_gallery").append('<div class="large"><img src="'+code+'" class="img" alt="" /><br /></div>');
//		if (isMobile==0) {
//			$(".layer_gallery").append('<div class="layer_gallery_control"><ul><li class="zoomin"><a href="#"><img src="/wcm/images/common/btn/btn_zoomin.png" alt="Zoom In" /></a></li><li class="zoomout" style="display:none;"><a href="#"><img src="/wcm/images/common/btn/btn_zoomout.png" alt="Zoom Out" /></a></li></ul></div>');
//			$(".layer_gallery").append('<div class="minimap"><div class="in"><img src="'+code+'" class="small" /><br /><div class="move"><img src="/wcm/images/common/bg/blank.gif" alt="" /></div></div></div>');
//			$(".layer_gallery_control .zoomin a").click(function() {galleryZoomIn()});
//			$(".layer_gallery_control .zoomout a").click(function() {galleryZoomOut()});
//			$(".layer_gallery .minimap .in .move").draggable({containment:".layer_gallery .minimap .in", cursor:"move",
//				start:function(event) {},
//				stop:function(event) {
//					// image size - 1920*1152 // 108 * 64
//					var x = parseInt(parseInt($(this).css("left"))*1920/108) * -1;
//					var y = parseInt(parseInt($(this).css("top"))*1152/64) * -1;
//					$(".layer_gallery .large").css("left",x).css("top",y);
//				}
//			});
//		}
//	} else { // movie
//		$(".layer_gallery").append('<div class="large_movie"><iframe width="574" height="460" src="'+code+'" frameborder="0" allowfullscreen></iframe></div>');
//	}
//	if (isMain!="main") {
//		$(".layer_gallery").append('<div class="layer_gallery_left"><a href="#"><img src="/wcm/images/common/btn/btn_layer_left.png" alt="previous" /></a><br /></div>');
//		$(".layer_gallery").append('<div class="layer_gallery_right"><a href="#"><img src="/wcm/images/common/btn/btn_layer_right.png" alt="next" /></a><br /></div>');
//	}
//	var tmp_strumbleCode = "";
//	if (isImg=="image") {
//		tmp_strumbleCode = "";
//	}else {
//		tmp_strumbleCode = '<a href="'+stumbleupon+'"><img src="/wcm/images/common/icon/icon_su_black.gif" alt="" /></a>';
//	}
//	$(".layer_gallery").append('<div class="layer_gallery_links"><iframe src="http://www.facebook.com/plugins/like.php?href='+like+'&amp;send=false&amp;layout=button_count&amp;width=120&amp;show_faces=false&amp;action=like&amp;colorscheme=light&amp;font=arial&amp;height=21" scrolling="no" frameborder="0" style="border:none; overflow:hidden; width:120px; height:21px;" allowTransparency="true"></iframe> <span><img src="/wcm/images/'+country+'/cube/txt_download.png" alt="" /></span> <a href="'+download+'"><img src="/wcm/images/common/btn/btn_cube_gallery_download.png" alt="" /></a> <span><img src="/wcm/images/'+country+'/cube/txt_share.png" alt="" /></span> <a href="'+facebook+'"><img src="/wcm/images/common/btn/btn_cube_gallery_facebook.png" alt="" /></a> <a href="'+twitter+'"><img src="/wcm/images/common/btn/btn_cube_gallery_twitter.png" alt="" /></a> '+tmp_strumbleCode+'</div>');
//	galleryPopup();
//	fadeinout('.layer_gallery','fadein');
//}
//function fadeinout(selector, op) {
//	if (op=="fadein") {$(selector).fadeIn();} else {$(selector).fadeOut();}
//	var h=$(document).height()
//	$(selector).css("height",h);
//}
//function galleryOver() {
//	$(".gallerylist img.cover").remove();
//	$(".gallerylist li a").each(function() {
//		var classname = $(this).attr("class");
//		var appendobj="";
//		if (classname=="exterior") {
//			$(this).append('<img src="/wcm/images/es/cube/gallery_item_cover_exterior.png" class="cover" alt="" />');
//		} else if (classname=="interior") {
//			$(this).append('<img src="/wcm/images/es/cube/gallery_item_cover_interior.png" class="cover" alt="" />');
//		} else if (classname=="movie") {
//			$(this).append('<img src="/wcm/images/es/cube/gallery_item_cover_movie2.png" class="cover" alt="" />');
//		}
//		$(this).bind("mouseover",function(){
//			$("img.cover",$(this)).css("zIndex",10);
//		});
//		$(this).bind("mouseout",function(){
//			$("img.cover",$(this)).css("zIndex",8);
//		});
//	});
//}
//function galleryPopup() {
//	var w = $(window).width();
//	var h = $(document).height();
//	if (w<960) {w=960};
//	$(".layer_gallery").css("width",w).css("height",h);
//	$(".layer_gallery .large").css("width",w).css("left",0).css("top",0);
//	$(".layer_gallery .minimap .in .move").css("left",0).css("top",0);
//}
//function galleryZoomIn() { // image size - 1920*1152 // 108 * 64
//	var w=parseInt($(".layer_gallery .large img.img").css("width"));
//	var h=parseInt($(".layer_gallery .large img.img").css("height"));
//	$(".layer_gallery .large img.img").css("left",0);
//	$(".layer_gallery .large img.img").animate({"width":1920},{duration:900,easing:"motion"});
//	$(".layer_gallery_control .zoomin").hide();
//	$(".layer_gallery_control .zoomout").show();
//	$(".layer_gallery .minimap").show();
//	var all_w = $(window).width();
//	var all_h = $(window).height();
//	var img_w = 1920;
//	var img_h = 1152;
//	var ratio_w = parseInt((all_w/img_w)*100) * 108 / 100;
//	var ratio_h = parseInt((all_h/img_h)*100) * 64 / 100;
//	$(".layer_gallery .minimap .in .move").css("width",ratio_w).css("height",ratio_h).css("left",0).css("top",0);
//}
//function galleryZoomOut() { // image size - 1920*1152 // 108 * 64
//	var w=parseInt($(".layer_gallery .large img.img").css("width"));
//	var h=parseInt($(".layer_gallery .large img.img").css("height"));
//	$(".layer_gallery .large img.img").css("left",0);
//	if ($(window).width()<960) {
//		$(".layer_gallery .large img.img").animate({"width":960},{duration:900,easing:"motion"});
//	} else {
//		$(".layer_gallery .large img.img").animate({"width":$(window).width()},{duration:900,easing:"motion"});
//	}
//	$(".layer_gallery .large").css("left",0).css("top",0);
//	$(".layer_gallery .minimap .in .move").css("left",0).css("top",0);
//	$(".layer_gallery_control .zoomin").show();
//	$(".layer_gallery_control .zoomout").hide();
//	$(".layer_gallery .minimap").hide();
//}
/* scroll animation */
function scrollAnimation() {
	if(isMobile==0){
		$('a[href*=#pip], a[href*=#slide_content01], a[href*=#slide_content02], a[href*=#slide_content03], a[href*=#slide_content04], a[href*=#slide_content05], a[href*=#slide_content06], a[href*=#slide_content07], a[href*=#slide_content08], area[href*=#pip], area[href*=#slide_content01], area[href*=#slide_content02], area[href*=#slide_content03], area[href*=#slide_content04], area[href*=#slide_content05], area[href*=#slide_content06], area[href*=#slide_content07], area[href*=#slide_content08]').click(function() {
		    debugger;
			if (navigator.userAgent.match(/MSIE/i)) {
				initSubmenuHighlight();
				$(this).addClass("on");
			}
			
			if (location.pathname.replace(/^\//,'') == this.pathname.replace(/^\//,'') && location.hostname == this.hostname) {
				var $target = $(this.hash);
				$target = $target.length && $target || jQuery('[name=' + this.hash.slice(1) +']');
				if ($target.length) {
					var targetOffset = $target.offset().top;
					jQuery('html,body').animate({scrollTop:targetOffset}, {duration:500, easing:'motion'});
					return false;
				} else {
					return true;
				}
			} else {
				return true;
			}
		});
	} else {
		$('a[href*=#pip]').click(function() {goToMyId('wrap');});
		$('a[href*=#slide_content01]').click(function() {goToMyId('slide_content01');});
		$('a[href*=#slide_content02]').click(function() {goToMyId('slide_content02');});
		$('a[href*=#slide_content03]').click(function() {goToMyId('slide_content03');});
		$('a[href*=#slide_content04]').click(function() {goToMyId('slide_content04');});
		$('a[href*=#slide_content05]').click(function() {goToMyId('slide_content05');});
		$('a[href*=#slide_content06]').click(function() {goToMyId('slide_content06');});
		$('a[href*=#slide_content07]').click(function() {goToMyId('slide_content07');});
		$('a[href*=#slide_content08]').click(function() {goToMyId('slide_content08');});
		$('area[href*=#pip]').click(function() {goToMyId('wrap');});
		$('area[href*=#slide_content01]').click(function() {goToMyId('slide_content01');});
		$('area[href*=#slide_content02]').click(function() {goToMyId('slide_content02');});
		$('area[href*=#slide_content03]').click(function() {goToMyId('slide_content03');});
		$('area[href*=#slide_content04]').click(function() {goToMyId('slide_content04');});
		$('area[href*=#slide_content05]').click(function() {goToMyId('slide_content05');});
		$('area[href*=#slide_content06]').click(function() {goToMyId('slide_content06');});
		$('area[href*=#slide_content07]').click(function() {goToMyId('slide_content07');});
		$('area[href*=#slide_content08]').click(function() {goToMyId('slide_content08');});
		if (!location.hash || location.hash=="#pip") {
			setTimeout(scrollTo, 0, 0, 1);
		} else {
			if (location.hash=="#slide_content01") {goToMyId('slide_content01');}
			if (location.hash=="#slide_content02") {goToMyId('slide_content02');}
			if (location.hash=="#slide_content03") {goToMyId('slide_content03');}
			if (location.hash=="#slide_content04") {goToMyId('slide_content04');}
			if (location.hash=="#slide_content05") {goToMyId('slide_content05');}
			if (location.hash=="#slide_content06") {goToMyId('slide_content06');}
			if (location.hash=="#slide_content07") {goToMyId('slide_content07');}
			if (location.hash=="#slide_content08") {goToMyId('slide_content08');}
		}
	}
}
function goToMyId(myid) { // 해당 ID값으로 직진, 이동하고 나면, 포지션 정리함.
	var target = $('div[id='+myid+']');
	if (target.length){var top = target.offset().top;
		$('html,body').animate({scrollTop:top},{duration:1000,easing:'motion',complete:function() {
			fixedPositionScroll();changeSubmenuHighlight();
		}});
		return false;
	}
}
/* fix position:fixed */
function fixedPosition() {
	var w = parseInt(($(window).width()-960)/2);
	if (w<0) w=0;
	if ($(window).scrollTop() > 410) {
		if (isPositionFixed==0) {
			$(".wrap .floating_cubemenu").css("position","absolute");
			$(".wrap .floating_cubemenu").css("left",w+11);
		} else {
			$(".wrap .floating_cubemenu").css("position","fixed");
			$(".wrap .floating_cubemenu").css("left",w+11);
		}
	} else {
		$(".wrap .floating_cubemenu").css("position","absolute");
		$(".wrap .floating_cubemenu").css("left",w-1+11);
	}
	$(".wrap").css("width",$(window).width()).css("overflow","hidden");
	$(".objects_box").css("width",$("window").width()).css("overflow","hidden");

	if (w<=0) {
		$(".prevbtn").css("left",17);
		$(".nextbtn").css("right",17);
	} if (w>100) {
		$(".prevbtn").css("left",-100);
		$(".nextbtn").css("right",-100);
	} else {
		$(".prevbtn").css("left",w*-1);
		$(".nextbtn").css("right",w*-1);
	}
}
function fixedPositionScroll() {
	var w = parseInt(($(window).width()-960)/2);
	if (w<0) w=0;
	if ($(window).scrollTop() >= 410) {
		if (isPositionFixed==0) $(".wrap .floating_cubemenu").css("top",$(window).scrollTop()-60);
		else $(".wrap .floating_cubemenu").css("top",0);
	} else {
		$(".wrap .floating_cubemenu").css("top",0);
	}
}
//function readyCube() {
//	$(".cubelist").autoSlide('cube'); // option : 'cube' or Paging div's class name
//	$(".mainbanner .banners").autoSlide('paging_touch');
//}

//$.fn.autoSlide = function(op) {
//	var settings = {duration: 300,direction: "horizontal",minimumDrag: 20, easing: "motion" ,beforeStart: function(){},afterStart: function(){},beforeStop: function(){},afterStop: function(){}};
//	var isCube=0;
//	if (op=="cube") {isCube=1;}
//	return this.each(function() {
//		var originalList = $(this);
//		var pages = originalList.children();
//		var width = originalList.width();
//		var height = originalList.height();

//		var containerCss = {position: "relative", overflow: "hidden", width: width, height: height};
//		var listCss = {position: "relative", padding: "0", margin: "0", listStyle: "none", width: pages.length * width};
//		var listItemCss = {width: width, height: height};
//		var container = $("<div>").attr("class",originalList.attr("class")).css(containerCss);
//		var list = $("<div class='items'>").css(listCss);
//		var currentPage = 1, start, stop;
//		if (settings.direction.toLowerCase() === "horizontal") {
//			list.css({float: "left"});
//			$.each(pages, function(i) {
//				var li = $("<div>").attr("class", "item")
//					//.css($.extend(listItemCss, {float: "left"}))
//					.html($(this).html());
//				list.append(li);
//			});
//			list.draggable({
//				axis: "x",
//				start: function(event) {
//					settings.beforeStart.apply(list, arguments);
//					var data = event.originalEvent.touches ? event.originalEvent.touches[0] : event;
//					start = {coords: [ data.pageX, data.pageY ]};
//					settings.afterStart.apply(list, arguments);
//				},
//				stop: function(event) {
//					settings.beforeStop.apply(list, arguments);
//					var data = event.originalEvent.touches ? event.originalEvent.touches[0] : event;
//					stop = {coords: [ data.pageX, data.pageY ]};

//					if (op=="cube") {
//						var h=0,v=0,hs=0,vs=0;
//						h = start.coords[0] - stop.coords[0];
//						if (h<0) hs=h*-1;
//						else hs=h;
//						v = start.coords[1] - stop.coords[1];
//						if (v<0) vs=v*-1;
//						else vs=v;
//						if (hs>vs) {
//							function moveLeft() {
//								if (currentPage === pages.length || dragDelta() < settings.minimumDrag) {list.animate({ left: "+=" + dragDelta()}, settings.duration, settings.easing);return;}
//								var new_width = -1 * width * currentPage;
//								list.animate({ left: new_width}, settings.duration, settings.easing);
//								currentPage++;
//							}
//							function moveRight() {
//								if (currentPage === 1 || dragDelta() < settings.minimumDrag) {list.animate({ left: "-=" + dragDelta()}, settings.duration, settings.easing);return;}
//								var new_width = -1 * width * (currentPage - 1);
//								list.animate({ left: -1 * width * (currentPage - 2)}, settings.duration, settings.easing);
//								currentPage--;
//							}
//							function dragDelta() {return Math.abs(start.coords[0] - stop.coords[0]);}
//							function adjustment() {return width - dragDelta();}
//							start.coords[0] > stop.coords[0] ? moveLeft() : moveRight();
//							settings.afterStop.apply(list, arguments);
//							if (currentPage > pages.length) currentPage=pages.length;
//							view_cube(currentPage,originalList);
//						} else {
//							if (v>10) {
//								$('html,body').animate({scrollTop:vs*3}, 1000, 'motion');
//							} else if (v<-10) {
//								$('html,body').animate({scrollTop:vs*3}, 1000, 'motion');
//							}
//						}
//					} else {
//						function moveLeft() {
//							if (currentPage === pages.length || dragDelta() < settings.minimumDrag) {list.animate({ left: "+=" + dragDelta()}, settings.duration, settings.easing);return;}
//							var new_width = -1 * width * currentPage;
//							list.animate({ left: new_width}, settings.duration, settings.easing);
//							currentPage++;
//						}
//						function moveRight() {
//							if (currentPage === 1 || dragDelta() < settings.minimumDrag) {list.animate({ left: "-=" + dragDelta()}, settings.duration, settings.easing);return;}
//							var new_width = -1 * width * (currentPage - 1);
//							list.animate({ left: -1 * width * (currentPage - 2)}, settings.duration, settings.easing);
//							currentPage--;
//						}
//						start.coords[0] > stop.coords[0] ? moveLeft() : moveRight();
//						function dragDelta() {return Math.abs(start.coords[0] - stop.coords[0]);}
//						function adjustment() {return width - dragDelta();}
//						settings.afterStop.apply(list, arguments);
//						if (currentPage > pages.length) currentPage=pages.length;
//						view_cube(currentPage,originalList);
//					}
//				}
//			});
//		}
//		container.append(list);
//		originalList.replaceWith(container);
//		$(window).load(function(e){
//			scrollAnimation();
//			if (isCube==1) {
//				if (!firstCube) firstCube = 1;
//				view_cube(firstCube, originalList);
//			}
//		});
//		$(".carlist ul li.on a").click(function() {
//			view_cube(1, originalList);return false;
//		});
//		function view_cube(num,obj) {
//			cubeMotionJS(num);
//			//if (currentPage!=num) {
//				if (num>0 && num <= pages.length) {
//					$(".items", "."+obj.attr("class")).animate({left:-1* width * (num-1) + "px"},900, 'motion',function() {
//						change_button(num,obj);
//					});
//				}
//				if (num==0 || currentPage==0) {
//					$(".items", "."+obj.attr("class")).animate({left:0},900,'motion',function() {
//						change_button(1,obj);
//					});
//				}
//			//}
//		}
//		function change_button(num,obj) {
//			if (num>0 && num<=pages.length) {
//				//alert("c:"+num+"/"+pages.length);
//				currentPage=num;
//				if (isCube==1) {

//					// change cubemenu's style
//					for (var i=0; i<=$(".floating_cubemenu .cubemenu ul.cubeitem li a").length; i++) {
//						if (i==num-2) {
//							$(".floating_cubemenu .cubemenu ul.cubeitem li a").eq(i).addClass("on");
//						} else {
//							$(".floating_cubemenu .cubemenu ul.cubeitem li a").eq(i).removeClass("on");
//						}
//					}
//					// change left & right button
//					/*
//					if (num==1) $("div.prevbtn a img").attr("src","/wcm/images/common/bg/blank.gif");
//					else $("div.prevbtn a img").attr("src","/wcm/images/"+country+"/cube/left_"+cubeList[num-2]+".png");
//					if (num==pages.length) $("div.nextbtn a img").attr("src","/wcm/images/common/bg/blank.gif");
//					else $("div.nextbtn a img").attr("src","/wcm/images/"+country+"/cube/right_"+cubeList[num]+".png");
//					*/
//					if (num==1) $("div.prevbtn a img").attr("src","/wcm/images/common/bg/blank.gif");
//					else $("div.prevbtn a img").attr("src","/wcm/images/common/btn/btn_cube_left.png");
//					if (num==pages.length) $("div.nextbtn a img").attr("src","/wcm/images/common/bg/blank.gif");
//					else $("div.nextbtn a img").attr("src","/wcm/images/common/btn/btn_cube_right.png");

//					/*
//					motionBtn();
//					$("div.prevbtn").bind("mouseover",function() {$("div.prevbtn").stop();});
//					$("div.nextbtn").bind("mouseover",function() {$("div.prevbtn").stop();});
//					*/

//					/*
//					var TempTxtCarcube = "";
//					if (pages.length > 1) {
//						for (var i=1; i<=pages.length; i++) {
//							if (i==num) TempTxtCarcube = TempTxtCarcube + '<img src="/wcm/images/common/bg/cube_carlist_on.gif" alt="">';
//							else  TempTxtCarcube = TempTxtCarcube + '<img src="/wcm/images/common/bg/cube_carlist_off.gif" alt="">';
//						}
//						TempTxtCarcube = TempTxtCarcube + "<br />";
//						$(".carcube").empty();
//						$(".carcube").append(TempTxtCarcube);
//					}
//					*/

//					// cube motion
//					cubeStart(num);
//				}
//				//if (isCube==0) {
//					var tmpTxt = "";
//					pages.each(function(i) {
//						var now=i-1+2;
//						if (currentPage==now) {
//							if (isCube==1) tmpTxt = tmpTxt + '<a href="#"><img src="/wcm/images/common/bg/bg_pagingtouch_on2.png" alt="'+now+'" /></a>';
//							else tmpTxt = tmpTxt + '<a href="#"><img src="/wcm/images/common/bg/bg_pagingtouch_on.png" alt="'+now+'" /></a>';
//						} else {
//							tmpTxt = tmpTxt + '<a href="#"><img src="/wcm/images/common/bg/bg_pagingtouch_off.png" alt="'+now+'" /></a>';
//						}
//					});
//					tmpTxt = tmpTxt + '<br />';
//					$("."+op).replaceWith('<div class="'+op+'">'+tmpTxt+'</div>');
//					$("."+op).css("width",pages.length*26);
//					if (isCube==0) {
//						$("."+op).css("margin","0 auto");
//					} else {
//						$("."+op).css("paddingLeft",parseInt((960-pages.length*26)/2));
//					}
//					if (op=="paging_touch") {
//						if (num==1) {
//							$(".mainbanner a.prev").replaceWith('<span class="prev">prev</span>');
//						} else {
//							$(".mainbanner a.prev").replaceWith('<a class="prev" href="#">prev</a>');
//							$(".mainbanner span.prev").replaceWith('<a class="prev" href="#">prev</a>');
//							$(".mainbanner a.prev").bind("click",function(e) {
//								view_cube(currentPage-1,originalList);return false;
//							});
//						}
//						if (num==pages.length) {
//							$(".mainbanner a.next").replaceWith('<span class="next">next</span>');
//						} else {
//							$(".mainbanner a.next").replaceWith('<a class="next" href="#">next</a>');
//							$(".mainbanner span.next").replaceWith('<a class="next" href="#">next</a>');
//							$(".mainbanner a.next").bind("click",function(e) {
//								view_cube(currentPage-1+2,originalList);return false;
//							});
//						}
//					}
//					$("a", "."+op).click(function() {
//						view_cube($("img", this).attr("alt"),originalList);return false;
//					});
//				//}
//			}
//		}
//		function LeftBtn() {var nowcube = currentPage;if (!nowcube) nowcube=1;view_cube(nowcube-1,  originalList);return false;}
//		function RightBtn() {var nowcube = currentPage;if (!nowcube) nowcube=1;view_cube(nowcube-1+2,  originalList);return false;}
//		if (isCube==1) {
//			$(".cubebox .prevbtn a").click(function() {LeftBtn();});
//			$(".cubebox .nextbtn a").click(function() {RightBtn();});
//			$(".floating_cubemenu .cubemenu ul.cubeitem li a").click(function(e) {
//				var num = $("span", $(this)).html();
//				num=num-1+1;
//				$(".cubelist .items").animate({
//					left:"-960" * num - "-960" + "px"
//				},900,'motion');
//				//change_button(num);
//				view_cube(num, originalList);
//				$(".floating_cubemenu .cubemenu .information").removeClass("on");
//				initSubmenuHighlight();
//			});
//			$(".floating_cubemenu .cubemenu .information .home a").click(function() {
//				view_cube(1,originalList);
//				$(".floating_cubemenu .cubemenu .information").addClass("on");
//				initSubmenuHighlight();
//			});

//			$(".cubebox .cubelist .item .info .vr360").click(function() {view_cube(3,originalList);return false;});
//		}
//	});
//};
//function initSubmenuHighlight() {
//	/*
//	for (var i=0; i< highlightItemName.length; i++) {
//		$(".submenu a").eq(i).removeClass("on");
//	}
//	*/
//	for (var i=0; i< $(".submenu a").length; i++) {
//		$(".submenu a").eq(i).removeClass("on");
//	}
//}
//function changeSubmenuHighlight() {
//	if (document.getElementById("pip") || document.getElementById("general")) {
//		for (var i=0; i< $(".submenu a").length; i++) {
//			if ($(".submenu a").eq(i).attr("href") != "#") {
//				var tmp = $(".submenu a").eq(i).attr("href").split("#");
//				var tmpz = $(".submenu a").eq(0).attr("href").split("#");
//				if ($(window).scrollTop() >= $("#"+tmp[1]).offset().top - 60) {
//					initSubmenuHighlight();
//					if ($(window).scrollTop() >= 460) {
//						$(".submenu a").eq(i).addClass("on");
//					}
//				}
//			}
//		}
//	}
//}
//$.fn.panorama = function(options) {
//	this.each(function(){
//		var settings = {views_number: 180,views_columns: 20};
//		var pano_element = this;
//		var orig_src = $(this).attr("src");
//		var loaded = 0;
//		var pano_mouse_position_x;
//		var pano_mouse_position_y;
//		var pano_mouse_delta_x = 0;
//		var pano_mouse_delta_y = 0;
//		var pano_mouse_down = false;
//		var pano_current_number;
//		var pano_timer;
//		var pano_loading_stop = false;
//		var pano_width = parseInt($(pano_element).attr("width"));
//		pano_mouse_position_x = parseInt(pano_width/2);
//		var pano_height = parseInt($(pano_element).attr("height"));
//		pano_mouse_position_y = parseInt(pano_height/2);
//		$(pano_element).css("margin", "0 0 0 0").css("padding", "0 0 0 0").wrap('<div class="panorama" style="position: relative; margin: 0; padding: 0; height: '+pano_height+'px; width: '+pano_width+'px; overflow: hidden;"></div>');
//		if(options) $.extend(settings, options);
//		$(pano_element).after('<a class="pano_loading_stop" href="#" style="display: none; color: white; position: absolute; top: 5px; right: 5px; text-decoration: none;">[stop]</a>');
//		if (settings.views_columns==settings.views_number) { // exterior
//			$(pano_element).after('<p class="pano_loading_percent" style="position: absolute; display: none; top: '+parseInt(pano_height/2-45)+'px; left: '+parseInt(pano_width/2-45)+'px; text-align: center; width:90px; height:90px;"><img src="/wcm/images/'+country+'/loading.gif" alt="loading" /><span style="display:block;width:45px;margin:-29px auto 0 auto;font-size:12px;color:#333;background:url(/wcm/images/common/bg/bg_loading_txt.gif) repeat-x 0 0;">loading</span></p>');
//		} else { // interior
//			$(pano_element).after('<p class="pano_loading_percent" style="position: absolute; display: none; top: '+parseInt(pano_height/2-45)+'px; left: '+parseInt(pano_width/2-45)+'px; text-align: center; width:90px; height:90px;"><img src="/wcm/images/'+country+'/loading.gif" alt="loading" /><span style="display:block;width:45px;margin:-29px auto 0 auto;font-size:12px;color:#333;background:url(/wcm/images/common/bg/bg_loading_txt.gif) repeat-x 0 0;">loading</span></p>');
//		}
//		var src_prefix = orig_src.substr(0, orig_src.lastIndexOf('_')+1);
//		var src_number = parseInt(orig_src.substr(orig_src.lastIndexOf('_')+1));
//		pano_current_number = src_number;
//		var src_sufix = orig_src.substr(orig_src.indexOf(src_number,0)+String(src_number).length);
//		if (settings.views_columns==settings.views_number) { // exterior
//			$(pano_element).after('<p class="pano_loading_start" style="position: absolute; top: '+parseInt(pano_height/2-45)+'px; left: '+parseInt(pano_width/2-45)+'px;text-align: center; width:90px; height:90px;"><a href="#"><img src="/wcm/images/'+country+'/btn/btn_start.png" alt="Start" /></a></p>');
//		} else { // interior
//			$(pano_element).after('<p class="pano_loading_start" style="position: absolute; top: '+parseInt(pano_height/2-45)+'px; left: '+parseInt(pano_width/2-45)+'px;text-align: center; width:90px; height:90px;"><a href="#"><img src="/wcm/images/'+country+'/btn/btn_start2.png" alt="Start" /></a></p>');
//		}
//		$(pano_element).after('<div class="pano_loading_masque" style="position: absolute; top: 0; left: 0; width: '+pano_width+'px; height: '+pano_height+'px; opacity: .5; filter:alpha(opacity=50);"></div>');
//		$(pano_element).parent().find(".pano_loading_stop").bind('click', function(){
//			pano_loading_stop = true;
//			return false;
//		});
//		$(pano_element).parent().find(".pano_loading_start a").bind('click', function(){
//			$(pano_element).parent().css("cursor", "wait");
//			$(pano_element).parent().find(".pano_loading_start").hide();
//			$(pano_element).parent().find(".pano_loading_percent").show();
//			$(pano_element).parent().find(".pano_loading_animation").show();
//			$(pano_element).parent().find(".pano_vues").remove();
//			pano_timer = setTimeout(function(){
//				clearTimeout(pano_timer);
//				for (var i=0; i<settings.views_number; i++) {
//					if (i!=src_number){
//						$(pano_element).after('<img class="pano_vues vue'+i+'" src="'+src_prefix+i+src_sufix+'" style="visibility: hidden;" />');
//						$(pano_element).parent().find("img.vue"+i).bind('load', function(){
//							//if ($(pano_element).parent().find(".pano_loading_stop").css("display")=="none") $(pano_element).parent().find(".pano_loading_stop").show();
//							loaded++;
//							if (pano_loading_stop) {
//								pano_loading_stop=false;
//								//$(pano_element).parent().find(".pano_loading_stop").hide();
//								$(pano_element).parent().css("cursor", "default");
//								$(pano_element).parent().find(".pano_loading_percent").hide();
//								$(pano_element).parent().find(".pano_loading_start").show();
//								$(pano_element).parent().find(".pano_loading_percent span").html('loading');
//								pano_timer = setTimeout(function(){
//									 clearTimeout(pano_timer); window.stop();
//								});

//							}
//							//if (loaded >= (settings.views_number-1)) {
//							if (parseInt((loaded/settings.views_number)*100) > 90) {
//								$(pano_element).parent().css("cursor", "pointer");
//								//$(pano_element).parent().find(".pano_loading_stop").hide();
//								$(pano_element).parent().find(".pano_loading_percent").hide();
//								$(pano_element).parent().find(".pano_loading_animation").hide();
//								$(pano_element).parent().find(".pano_loading_masque").hide();
//								$(pano_element).bind('mousedown', function(e){
//									pano_mouse_down = true;
//									pano_mouse_position_x = e.clientX;
//									pano_mouse_position_y = e.clientY;
//									$(pano_element).parent().css("cursor", "move");
//									return false;
//								});
//								$(pano_element).bind('mouseup', function(){
//									pano_mouse_down = false;
//									$("div.panorama").css("cursor", "pointer");
//									return false;
//								});
//								$(pano_element).bind('mousemove', function(e){
//										if (pano_mouse_down) {
//										pano_mouse_delta_x = parseInt((pano_mouse_position_x - e.clientX)/20);
//										pano_mouse_delta_y = parseInt((pano_mouse_position_y - e.clientY)/20);
//										if (pano_mouse_delta_x!=0||pano_mouse_delta_y!=0) {
//											var pageCoords = "( " + e.pageX + ", " + e.pageY + " )";
//												var clientCoords = "( " + e.clientX + ", " + e.clientY + " )";
//												//src_number1=parseInt((settings.views_columns/pano_width)*pano_mouse_delta_x);
//												//src_number=pano_current_number+src_number1+settings.views_number-settings.views_columns*parseInt(-5+((settings.views_number/settings.views_columns)/pano_height)*pano_mouse_delta_y);
//											pano_current_number=pano_current_number+pano_mouse_delta_x+settings.views_columns*pano_mouse_delta_y;
//											if (pano_current_number<0)
//												//pano_current_number = 0;
//												pano_current_number = settings.views_columns-1;
//											if (pano_current_number>(settings.views_number-1))
//												pano_current_number = settings.views_number-settings.views_columns;
//											$(pano_element).attr('src', src_prefix+pano_current_number+src_sufix);
//											pano_mouse_position_x= e.clientX;
//											pano_mouse_position_y= e.clientY;
//										}

//									}
//									return false;
//								});
//							}
//							else {
//								$(pano_element).parent().find(".pano_loading_percent span").html(parseInt((loaded/settings.views_number)*100) + " %");
//							}
//						});
//					}
//				}
//			}, 500);
//			return false;
//		});
//	});
//};
//$.fn.txtloopit = function(op) {
//	this.each(function(){
//		//var my_chars=["h", "y", "u", "n", "d", "a", "i","e", "w","t","h", "k","g","p", "o","s","b","l"];
//		var my_chars=[" "," "];
//		var my_array=[];
//		var my_position=0;
//		var temp_str=""
//		var end_str="";
//		var charNumber=0;
//		var p;
//		var t;
//		if (op) {loopit($(this),op);}
//		function loopit(thediv, my_str) {
//			var my_array = my_str.split("");
//			if(my_position < my_array.length+1){
//				for (var i = 0; i<(my_array.length - end_str.length); i++) {
//					charNumber = Math.floor(Math.random()*my_chars.length);
//					temp_str += my_chars[charNumber];
//				}
//				thediv.empty();
//				thediv.append(end_str+temp_str);
//				temp_str = "";
//				end_str += my_array[my_position];
//				my_position++;
//				p=setTimeout(function(){loopit(thediv,my_str)}, 20);
//			}else{
//				my_position = 0;
//				temp_str = "";
//				end_str = "";
//				clearTimeout(p);
//			}
//			thediv.css("visibility","visible");
//		}
//	});
//};
//function showTranslucency() { // show translucency layer
//	var obj = document.getElementById("translucency");
//	setOpacity(obj, 50);
//	obj.style.display="block";
//	var h=$(document).height() + 30;
//	$("#translucency").css("height",h);
//}
//function hideTranslucency() { // hide translucency layer
//	var obj = document.getElementById("translucency");
//	obj.style.display="none";
//}
//function setOpacity(id, op) { // set opacity
//	var obj = id.style;
//	obj.opacity = (op/100);
//	obj.filter = "alpha(opacity="+op+")";
//	obj.MozOpacity=(op/100);
//	obj.KhtmlOpacity=(op/100);
//}

//$(function(){
//	if (!document.getElementById("search_select")) return false;
//	$('.find_accessories .search').jqTransform({imgPath:'/wcm/images/common/jqtransform/'});
//	$('.usedcar_top').jqTransform({imgPath:'/wcm/images/common/jqtransform/'});
//	$('.inquiry_table .select_title').jqTransform({imgPath:'/wcm/images/common/jqtransform/'});
//	$('.form_table .select_title').jqTransform({imgPath:'/wcm/images/common/jqtransform/'});
//	$('.inquiry_table .select_topic').jqTransform({imgPath:'/wcm/images/common/jqtransform/'});
//	$('#form .select_design').jqTransform({imgPath:'/wcm/images/common/jqtransform/'});
//	$('.contents_accessories #search_select').jqTransform({imgPath:'/wcm/images/common/jqtransform/'});
//	$('.slide_content_last .select_trim #selectbox').jqTransform({imgPath:'/wcm/images/common/jqtransform/'});
//	$('.most_like .sort').jqTransform({imgPath:'/wcm/images/common/jqtransform/'});
//	$('#layer_popup .select_topic').jqTransform({imgPath:'/wcm/images/common/jqtransform/'});
//	$('.con_popup .select_topic').jqTransform({imgPath:'/wcm/images/common/jqtransform/'});
//	$('.car_builder .options_lists').jqTransform({imgPath:'/wcm/images/common/jqtransform/'});
//	$('.choose_trim').jqTransform({imgPath:'/wcm/images/common/jqtransform/'});
//	$('.list_package').jqTransform({imgPath:'/wcm/images/common/jqtransform/'});
//	$('.carfinder .category').jqTransform({imgPath:'/wcm/images/common/jqtransform/'});
//	$('.accessories_options .search').jqTransform({imgPath:'/wcm/images/common/jqtransform/'});
//});

//window.onload = function() {
//	var fincolor=document.getElementById('color');
//	if(fincolor) initTabMenu("color");
//}

///* tab menu */
//function initTabMenu(tabContainerID) {
//	var tabContainer = document.getElementById(tabContainerID);
//	var tabAnchor = tabContainer.getElementsByTagName("a");
//	var i = 0;

//	for(i=0; i<tabAnchor.length; i++) {
//		if (tabAnchor.item(i).className == "tab")
//			thismenu = tabAnchor.item(i);
//		else
//			continue;

//		thismenu.container = tabContainer;
//		thismenu.targetEl = document.getElementById(tabAnchor.item(i).href.split("#")[1]);
//		thismenu.targetEl.style.display = "none";
//		thismenu.imgEl = thismenu.getElementsByTagName("img").item(0);
//		thismenu.onclick = function tabMenuClick() {
//			currentmenu = this.container.current;
//			if (currentmenu == this)
//				return false;

//			if (currentmenu) {
//				currentmenu.targetEl.style.display = "none";
//				if (currentmenu.imgEl) {
//					currentmenu.imgEl.src = currentmenu.imgEl.src.replace("_on.gif", "_off.gif");
//				} else {
//					currentmenu.className = currentmenu.className.replace(" on", "off");
//				}
//			}
//			this.targetEl.style.display = "";
//			if (this.imgEl) {
//				this.imgEl.src = this.imgEl.src.replace("_off.gif", "_on.gif");
//			} else {
//				this.className += " on";
//			}
//			this.container.current = this;

//			return false;
//		};

//		if (!thismenu.container.first)
//			thismenu.container.first = thismenu;
//	}
//	if (tabContainer.first)
//		tabContainer.first.onclick();
//}

///* special menu */
//function menuOver() {
//	this.getElementsByTagName("img").item(0).src = this.getElementsByTagName("img").item(0).src.replace("_off.gif", "_on.gif");
//}
//function menuOut() {
//	this.getElementsByTagName("img").item(0).src = this.getElementsByTagName("img").item(0).src.replace("_on.gif", "_off.gif");
//}

//function initSubmenu(depth1, depth2, depth3) {
//	var selectDepth1 = "smenu" + depth1 + "-" + depth2;
//	var selectDepth2 = "smenu" + depth1 + "-" + depth2 + "-" + depth3;

//	var nav = document.getElementById("special_menu_inner");
//	var menuEl = nav.getElementsByTagName("li");
	
//	for(i = 0; i < menuEl.length; i++) {
		
//		if (menuEl.item(i).id == selectDepth1) {
			
//			if(menuEl.item(i).getElementsByTagName("img").item(0)) {
//				menuEl.item(i).getElementsByTagName("img").item(0).src = menuEl.item(i).getElementsByTagName("img").item(0).src.replace("_off.gif", "_on.gif");
//			}
//			if (menuEl.item(i).getElementsByTagName("ul").item(0)) {
//				menuEl.item(i).getElementsByTagName("ul").item(0).style.display = "";
//			}
//		}else{
//			if(menuEl.item(i).getElementsByTagName("img").item(0)) {
//				menuEl.item(i).getElementsByTagName("img").item(0).src = menuEl.item(i).getElementsByTagName("img").item(0).src.replace("_on.gif", "_off.gif");
//			}
//			if (menuEl.item(i).getElementsByTagName("ul").item(0)) {
//				menuEl.item(i).getElementsByTagName("ul").item(0).style.display = "none";
//			}
//		}
		
//		if(menuEl.item(i).id == selectDepth2){
//			menuEl.item(i).className = "on";
//		}else{
//			menuEl.item(i).className = "";
//		}
		
//	}
//}

//function menu_onoff(sel){
//	sel_div = document.getElementById(sel);
//	if(sel_div.style.display=="none"){
//		sel_div.style.display="";
//	}else{
//		sel_div.style.display="none";
//	}
//}

///* Start the Plugin */
//(function($){
//	var defaultOptions = {preloadImg:true};
//	var jqTransformImgPreloaded = false;
//	var jqTransformPreloadHoverFocusImg = function(strImgUrl) {
//		//guillemets to remove for ie
//		strImgUrl = strImgUrl.replace(/^url\((.*)\)/,'$1').replace(/^\"(.*)\"$/,'$1');
//		var imgHover = new Image();
//		imgHover.src = strImgUrl.replace(/\.([a-zA-Z]*)$/,'-hover.$1');
//		var imgFocus = new Image();
//		imgFocus.src = strImgUrl.replace(/\.([a-zA-Z]*)$/,'-focus.$1');
//	};
//	/***************************
//	  Labels
//	***************************/
//	var jqTransformGetLabel = function(objfield){
//		var selfForm = $(objfield.get(0).form);
//		var oLabel = objfield.next();
//		if(!oLabel.is('label')) {
//			oLabel = objfield.prev();
//			if(oLabel.is('label')){
//				var inputname = objfield.attr('id');
//				if(inputname){
//					oLabel = selfForm.find('label[for="'+inputname+'"]');
//				}
//			}
//		}
//		if(oLabel.is('label')){return oLabel.css('cursor','pointer');}
//		return false;
//	};
//	/* Hide all open selects */
//	var jqTransformHideSelect = function(oTarget){
//		var ulVisible = $('.jqTransformSelectWrapper ul:visible');
//		ulVisible.each(function(){
//			var oSelect = $(this).parents(".jqTransformSelectWrapper:first").find("select").get(0);
//			//do not hide if click on the label object associated to the select
//			if( !(oTarget && oSelect.oLabel && oSelect.oLabel.get(0) == oTarget.get(0)) ){$(this).hide();}
//		});
//	};
//	/* Check for an external click */
//	var jqTransformCheckExternalClick = function(event) {
//		if ($(event.target).parents('.jqTransformSelectWrapper').length === 0) { jqTransformHideSelect($(event.target)); }
//	};
//	/* Apply document listener */
//	var jqTransformAddDocumentListener = function (){
//		$(document).mousedown(jqTransformCheckExternalClick);
//	};
//	/* Add a new handler for the reset action */
//	var jqTransformReset = function(f){
//		var sel;
//		$('.jqTransformSelectWrapper select', f).each(function(){sel = (this.selectedIndex<0) ? 0 : this.selectedIndex; $('ul', $(this).parent()).each(function(){$('a:eq('+ sel +')', this).click();});});
//		$('a.jqTransformCheckbox, a.jqTransformRadio', f).removeClass('jqTransformChecked');
//		$('input:checkbox, input:radio', f).each(function(){if(this.checked){$('a', $(this).parent()).addClass('jqTransformChecked');}});
//	};
//	/***************************
//	  Check Boxes
//	 ***************************/
//	$.fn.jqTransCheckBox = function(){
//		return this.each(function(){
//			if($(this).hasClass('jqTransformHidden')) {return;}

//			var $input = $(this);
//			var inputSelf = this;

//			//set the click on the label
//			var oLabel=jqTransformGetLabel($input);
//			oLabel && oLabel.click(function(){aLink.trigger('click');});

//			var aLink = $('<a href="#" class="jqTransformCheckbox"></a>');
//			//wrap and add the link
//			$input.addClass('jqTransformHidden').wrap('<span class="jqTransformCheckboxWrapper"></span>').parent().prepend(aLink);
//			//on change, change the class of the link
//			$input.change(function(){
//				this.checked && aLink.addClass('jqTransformChecked') || aLink.removeClass('jqTransformChecked');
//				return true;
//			});
//			// Click Handler, trigger the click and change event on the input
//			aLink.click(function(){
//				//do nothing if the original input is disabled
//				if($input.attr('disabled')){return false;}
//				//trigger the envents on the input object
//				$input.trigger('click').trigger("change");
//				return false;
//			});

//			// set the default state
//			this.checked && aLink.addClass('jqTransformChecked');
//		});
//	};
//	/***************************
//	  Radio Buttons
//	 ***************************/
//	$.fn.jqTransRadio = function(){
//		return this.each(function(){
//			if($(this).hasClass('jqTransformHidden')) {return;}

//			var $input = $(this);
//			var inputSelf = this;

//			oLabel = jqTransformGetLabel($input);
//			oLabel && oLabel.click(function(){aLink.trigger('click');});

//			var aLink = $('<a href="#" class="jqTransformRadio" rel="'+ this.name +'"></a>');
//			$input.addClass('jqTransformHidden').wrap('<span class="jqTransformRadioWrapper"></span>').parent().prepend(aLink);

//			$input.change(function(){
//				inputSelf.checked && aLink.addClass('jqTransformChecked') || aLink.removeClass('jqTransformChecked');
//				return true;
//			});
//			// Click Handler
//			aLink.click(function(){
//				if($input.attr('disabled')){return false;}
//				$input.trigger('click').trigger('change');

//				// uncheck all others of same name input radio elements
//				$('input[name="'+$input.attr('name')+'"]',inputSelf.form).not($input).each(function(){
//					$(this).attr('type')=='radio' && $(this).trigger('change');
//				});

//				return false;
//			});
//			// set the default state
//			inputSelf.checked && aLink.addClass('jqTransformChecked');
//		});
//	};

//	/***************************
//	  Select
//	 ***************************/
//	$.fn.jqTransSelect = function(){
//		return this.each(function(index){
//			var $select = $(this);
//			if($select.hasClass('jqTransformHidden')) {return;}
//			if($select.attr('multiple')) {return;}
//			var oLabel  =  jqTransformGetLabel($select);
//			/* First thing we do is Wrap it */
//			var $wrapper = $select
//				.addClass('jqTransformHidden')
//				.wrap('<div class="jqTransformSelectWrapper"></div>')
//				.parent()
//			/* Now add the html for the select */
//			$wrapper.prepend('<div><span></span><a href="#" class="jqTransformSelectOpen"></a></div><ul></ul>');
//			var $ul = $('ul', $wrapper).hide();
//			/* Now we add the options */
//			$('option', this).each(function(i){
//				var oLi = $('<li><a href="#" index="'+ i +'">'+ $(this).html() +'</a></li>');
//				$ul.append(oLi);
//			});
//			var obj = $(".jqTransformSelectWrapper");
//			var objNum = obj.length;
//			for(var i=0 ; i<objNum ;i++) {
//				$(".jqTransformSelectWrapper").eq(i).css({zIndex: 10-i});
//			}

//			/* Add click handler to the a */
//			$ul.find('a').click(function(){
//					$('a.selected', $wrapper).removeClass('selected');
//					$(this).addClass('selected');
//					/* Fire the onchange event */
//					if ($select[0].selectedIndex != $(this).attr('index') && $select[0].onchange) { $select[0].selectedIndex = $(this).attr('index'); $select[0].onchange(); }
//					$select[0].selectedIndex = $(this).attr('index');
//					$('span:eq(0)', $wrapper).html($(this).html());
//					$ul.hide();
//					return false;
//			});
//			/* Set the default */
//			$('a:eq('+ this.selectedIndex +')', $ul).click();
//			$('span:first', $wrapper).click(function(){$("a.jqTransformSelectOpen",$wrapper).trigger('click');});
//			oLabel && oLabel.click(function(){$("a.jqTransformSelectOpen",$wrapper).trigger('click');});
//			this.oLabel = oLabel;
//			/* Apply the click handler to the Open */
//			var oLinkOpen = $('a.jqTransformSelectOpen', $wrapper)
//				.click(function(){
//					//Check if box is already open to still allow toggle, but close all other selects
//					if( $ul.css('display') == 'none' ) {jqTransformHideSelect();}
//					if($select.attr('disabled')){return false;}
//					$ul.slideToggle('fast', function(){
//						/*
//						var offSet = ($('a.selected', $ul).offset().top - $ul.offset().top);
//						$ul.animate({scrollTop: offSet});
//						*/
//					});
//					return false;
//				});
//			// Set the new width
//			var iSelectWidth = $select.outerWidth();
//			var oSpan = $('span:first',$wrapper);
//			var newWidth = (iSelectWidth > oSpan.innerWidth())?iSelectWidth+oLinkOpen.outerWidth():$wrapper.width();
//			$wrapper.css('width',newWidth);
//			$ul.css('width',newWidth-2);
//			oSpan.css({width:iSelectWidth});
//			// Calculate the height if necessary, less elements that the default height
//			//show the ul to calculate the block, if ul is not displayed li height value is 0
//			$ul.css({display:'block',visibility:'hidden'});
//			var iSelectHeight = ($('li',$ul).length)*($('li:first',$ul).height());//+1 else bug ff
//			(iSelectHeight < $ul.height()) && $ul.css({height:iSelectHeight,'overflow':'hidden'});//hidden else bug with ff
//			$ul.css({display:'none',visibility:'visible'});
//		});
//	};
//	$.fn.jqTransform = function(options){
//		var opt = $.extend({},defaultOptions,options);
//		/* each form */
//		 return this.each(function(){
//			var selfForm = $(this);
//			if(selfForm.hasClass('jqtransformdone')) {return;}
//			selfForm.addClass('jqtransformdone');
//			$('input:checkbox', this).jqTransCheckBox();
//			$('input:radio', this).jqTransRadio();

//			if( $('select', this).jqTransSelect().length > 0 ){jqTransformAddDocumentListener();}
//			selfForm.bind('reset',function(){var action = function(){jqTransformReset(this);}; window.setTimeout(action, 10);});
//		}); /* End Form each */
//	};
//})(jQuery);;/* End the Plugin */

///* jQuery cycle.lite.min */
//(function($){var ver="2.88";if($.support==undefined){$.support={opacity:!($.browser.msie)};}function debug(s){if($.fn.cycle.debug){log(s);}}function log(){if(window.console&&window.console.log){window.console.log("[cycle] "+Array.prototype.join.call(arguments," "));}}$.fn.cycle=function(options,arg2){var o={s:this.selector,c:this.context};if(this.length===0&&options!="stop"){if(!$.isReady&&o.s){log("DOM not ready, queuing slideshow");$(function(){$(o.s,o.c).cycle(options,arg2);});return this;}log("terminating; zero elements found by selector"+($.isReady?"":" (DOM not ready)"));return this;}return this.each(function(){var opts=handleArguments(this,options,arg2);if(opts===false){return;}opts.updateActivePagerLink=opts.updateActivePagerLink||$.fn.cycle.updateActivePagerLink;if(this.cycleTimeout){clearTimeout(this.cycleTimeout);}this.cycleTimeout=this.cyclePause=0;var $cont=$(this);var $slides=opts.slideExpr?$(opts.slideExpr,this):$cont.children();var els=$slides.get();if(els.length<2){log("terminating; too few slides: "+els.length);return;}var opts2=buildOptions($cont,$slides,els,opts,o);if(opts2===false){return;}var startTime=opts2.continuous?10:getTimeout(els[opts2.currSlide],els[opts2.nextSlide],opts2,!opts2.rev);if(startTime){startTime+=(opts2.delay||0);if(startTime<10){startTime=10;}debug("first timeout: "+startTime);this.cycleTimeout=setTimeout(function(){go(els,opts2,0,(!opts2.rev&&!opts.backwards));},startTime);}});};function handleArguments(cont,options,arg2){if(cont.cycleStop==undefined){cont.cycleStop=0;}if(options===undefined||options===null){options={};}if(options.constructor==String){switch(options){case"destroy":case"stop":var opts=$(cont).data("cycle.opts");if(!opts){return false;}cont.cycleStop++;if(cont.cycleTimeout){clearTimeout(cont.cycleTimeout);}cont.cycleTimeout=0;$(cont).removeData("cycle.opts");if(options=="destroy"){destroy(opts);}return false;case"toggle":cont.cyclePause=(cont.cyclePause===1)?0:1;checkInstantResume(cont.cyclePause,arg2,cont);return false;case"pause":cont.cyclePause=1;return false;case"resume":cont.cyclePause=0;checkInstantResume(false,arg2,cont);return false;case"prev":case"next":var opts=$(cont).data("cycle.opts");if(!opts){log('options not found, "prev/next" ignored');return false;}$.fn.cycle[options](opts);return false;default:options={fx:options};}return options;}else{if(options.constructor==Number){var num=options;options=$(cont).data("cycle.opts");if(!options){log("options not found, can not advance slide");return false;}if(num<0||num>=options.elements.length){log("invalid slide index: "+num);return false;}options.nextSlide=num;if(cont.cycleTimeout){clearTimeout(cont.cycleTimeout);cont.cycleTimeout=0;}if(typeof arg2=="string"){options.oneTimeFx=arg2;}go(options.elements,options,1,num>=options.currSlide);return false;}}return options;function checkInstantResume(isPaused,arg2,cont){if(!isPaused&&arg2===true){var options=$(cont).data("cycle.opts");if(!options){log("options not found, can not resume");return false;}if(cont.cycleTimeout){clearTimeout(cont.cycleTimeout);cont.cycleTimeout=0;}go(options.elements,options,1,(!opts.rev&&!opts.backwards));}}}function removeFilter(el,opts){if(!$.support.opacity&&opts.cleartype&&el.style.filter){try{el.style.removeAttribute("filter");}catch(smother){}}}function destroy(opts){if(opts.next){$(opts.next).unbind(opts.prevNextEvent);}if(opts.prev){$(opts.prev).unbind(opts.prevNextEvent);}if(opts.pager||opts.pagerAnchorBuilder){$.each(opts.pagerAnchors||[],function(){this.unbind().remove();});}opts.pagerAnchors=null;if(opts.destroy){opts.destroy(opts);}}function buildOptions($cont,$slides,els,options,o){var opts=$.extend({},$.fn.cycle.defaults,options||{},$.metadata?$cont.metadata():$.meta?$cont.data():{});if(opts.autostop){opts.countdown=opts.autostopCount||els.length;}var cont=$cont[0];$cont.data("cycle.opts",opts);opts.$cont=$cont;opts.stopCount=cont.cycleStop;opts.elements=els;opts.before=opts.before?[opts.before]:[];opts.after=opts.after?[opts.after]:[];opts.after.unshift(function(){opts.busy=0;});if(!$.support.opacity&&opts.cleartype){opts.after.push(function(){removeFilter(this,opts);});}if(opts.continuous){opts.after.push(function(){go(els,opts,0,(!opts.rev&&!opts.backwards));});}saveOriginalOpts(opts);if(!$.support.opacity&&opts.cleartype&&!opts.cleartypeNoBg){clearTypeFix($slides);}if($cont.css("position")=="static"){$cont.css("position","relative");}if(opts.width){$cont.width(opts.width);}if(opts.height&&opts.height!="auto"){$cont.height(opts.height);}if(opts.startingSlide){opts.startingSlide=parseInt(opts.startingSlide);}else{if(opts.backwards){opts.startingSlide=els.length-1;}}if(opts.random){opts.randomMap=[];for(var i=0;i<els.length;i++){opts.randomMap.push(i);}opts.randomMap.sort(function(a,b){return Math.random()-0.5;});opts.randomIndex=1;opts.startingSlide=opts.randomMap[1];}else{if(opts.startingSlide>=els.length){opts.startingSlide=0;}}opts.currSlide=opts.startingSlide||0;var first=opts.startingSlide;$slides.css({position:"absolute",top:0,left:0}).hide().each(function(i){var z;if(opts.backwards){z=first?i<=first?els.length+(i-first):first-i:els.length-i;}else{z=first?i>=first?els.length-(i-first):first-i:els.length-i;}$(this).css("z-index",z);});$(els[first]).css("opacity",1).show();removeFilter(els[first],opts);if(opts.fit&&opts.width){$slides.width(opts.width);}if(opts.fit&&opts.height&&opts.height!="auto"){$slides.height(opts.height);}var reshape=opts.containerResize&&!$cont.innerHeight();if(reshape){var maxw=0,maxh=0;for(var j=0;j<els.length;j++){var $e=$(els[j]),e=$e[0],w=$e.outerWidth(),h=$e.outerHeight();if(!w){w=e.offsetWidth||e.width||$e.attr("width");}if(!h){h=e.offsetHeight||e.height||$e.attr("height");}maxw=w>maxw?w:maxw;maxh=h>maxh?h:maxh;}if(maxw>0&&maxh>0){$cont.css({width:maxw+"px",height:maxh+"px"});}}if(opts.pause){$cont.hover(function(){this.cyclePause++;},function(){this.cyclePause--;});}if(supportMultiTransitions(opts)===false){return false;}var requeue=false;options.requeueAttempts=options.requeueAttempts||0;$slides.each(function(){var $el=$(this);this.cycleH=(opts.fit&&opts.height)?opts.height:($el.height()||this.offsetHeight||this.height||$el.attr("height")||0);this.cycleW=(opts.fit&&opts.width)?opts.width:($el.width()||this.offsetWidth||this.width||$el.attr("width")||0);if($el.is("img")){var loadingIE=($.browser.msie&&this.cycleW==28&&this.cycleH==30&&!this.complete);var loadingFF=($.browser.mozilla&&this.cycleW==34&&this.cycleH==19&&!this.complete);var loadingOp=($.browser.opera&&((this.cycleW==42&&this.cycleH==19)||(this.cycleW==37&&this.cycleH==17))&&!this.complete);var loadingOther=(this.cycleH==0&&this.cycleW==0&&!this.complete);if(loadingIE||loadingFF||loadingOp||loadingOther){if(o.s&&opts.requeueOnImageNotLoaded&&++options.requeueAttempts<100){log(options.requeueAttempts," - img slide not loaded, requeuing slideshow: ",this.src,this.cycleW,this.cycleH);setTimeout(function(){$(o.s,o.c).cycle(options);},opts.requeueTimeout);requeue=true;return false;}else{log("could not determine size of image: "+this.src,this.cycleW,this.cycleH);}}}return true;});if(requeue){return false;}opts.cssBefore=opts.cssBefore||{};opts.animIn=opts.animIn||{};opts.animOut=opts.animOut||{};$slides.not(":eq("+first+")").css(opts.cssBefore);if(opts.cssFirst){$($slides[first]).css(opts.cssFirst);}if(opts.timeout){opts.timeout=parseInt(opts.timeout);if(opts.speed.constructor==String){opts.speed=$.fx.speeds[opts.speed]||parseInt(opts.speed);}if(!opts.sync){opts.speed=opts.speed/2;}var buffer=opts.fx=="shuffle"?500:250;while((opts.timeout-opts.speed)<buffer){opts.timeout+=opts.speed;}}if(opts.easing){opts.easeIn=opts.easeOut=opts.easing;}if(!opts.speedIn){opts.speedIn=opts.speed;}if(!opts.speedOut){opts.speedOut=opts.speed;}opts.slideCount=els.length;opts.currSlide=opts.lastSlide=first;if(opts.random){if(++opts.randomIndex==els.length){opts.randomIndex=0;}opts.nextSlide=opts.randomMap[opts.randomIndex];}else{if(opts.backwards){opts.nextSlide=opts.startingSlide==0?(els.length-1):opts.startingSlide-1;}else{opts.nextSlide=opts.startingSlide>=(els.length-1)?0:opts.startingSlide+1;}}if(!opts.multiFx){var init=$.fn.cycle.transitions[opts.fx];if($.isFunction(init)){init($cont,$slides,opts);}else{if(opts.fx!="custom"&&!opts.multiFx){log("unknown transition: "+opts.fx,"; slideshow terminating");return false;}}}var e0=$slides[first];if(opts.before.length){opts.before[0].apply(e0,[e0,e0,opts,true]);}if(opts.after.length>1){opts.after[1].apply(e0,[e0,e0,opts,true]);}if(opts.next){$(opts.next).bind(opts.prevNextEvent,function(){return advance(opts,opts.rev?-1:1);});}if(opts.prev){$(opts.prev).bind(opts.prevNextEvent,function(){return advance(opts,opts.rev?1:-1);});}if(opts.pager||opts.pagerAnchorBuilder){buildPager(els,opts);}exposeAddSlide(opts,els);return opts;}function saveOriginalOpts(opts){opts.original={before:[],after:[]};opts.original.cssBefore=$.extend({},opts.cssBefore);opts.original.cssAfter=$.extend({},opts.cssAfter);opts.original.animIn=$.extend({},opts.animIn);opts.original.animOut=$.extend({},opts.animOut);$.each(opts.before,function(){opts.original.before.push(this);});$.each(opts.after,function(){opts.original.after.push(this);});}function supportMultiTransitions(opts){var i,tx,txs=$.fn.cycle.transitions;if(opts.fx.indexOf(",")>0){opts.multiFx=true;opts.fxs=opts.fx.replace(/\s*/g,"").split(",");for(i=0;i<opts.fxs.length;i++){var fx=opts.fxs[i];tx=txs[fx];if(!tx||!txs.hasOwnProperty(fx)||!$.isFunction(tx)){log("discarding unknown transition: ",fx);opts.fxs.splice(i,1);i--;}}if(!opts.fxs.length){log("No valid transitions named; slideshow terminating.");return false;}}else{if(opts.fx=="all"){opts.multiFx=true;opts.fxs=[];for(p in txs){tx=txs[p];if(txs.hasOwnProperty(p)&&$.isFunction(tx)){opts.fxs.push(p);}}}}if(opts.multiFx&&opts.randomizeEffects){var r1=Math.floor(Math.random()*20)+30;for(i=0;i<r1;i++){var r2=Math.floor(Math.random()*opts.fxs.length);opts.fxs.push(opts.fxs.splice(r2,1)[0]);}debug("randomized fx sequence: ",opts.fxs);}return true;}function exposeAddSlide(opts,els){opts.addSlide=function(newSlide,prepend){var $s=$(newSlide),s=$s[0];if(!opts.autostopCount){opts.countdown++;}els[prepend?"unshift":"push"](s);if(opts.els){opts.els[prepend?"unshift":"push"](s);}opts.slideCount=els.length;$s.css("position","absolute");$s[prepend?"prependTo":"appendTo"](opts.$cont);if(prepend){opts.currSlide++;opts.nextSlide++;}if(!$.support.opacity&&opts.cleartype&&!opts.cleartypeNoBg){clearTypeFix($s);}if(opts.fit&&opts.width){$s.width(opts.width);}if(opts.fit&&opts.height&&opts.height!="auto"){$slides.height(opts.height);}s.cycleH=(opts.fit&&opts.height)?opts.height:$s.height();s.cycleW=(opts.fit&&opts.width)?opts.width:$s.width();$s.css(opts.cssBefore);if(opts.pager||opts.pagerAnchorBuilder){$.fn.cycle.createPagerAnchor(els.length-1,s,$(opts.pager),els,opts);}if($.isFunction(opts.onAddSlide)){opts.onAddSlide($s);}else{$s.hide();}};}$.fn.cycle.resetState=function(opts,fx){fx=fx||opts.fx;opts.before=[];opts.after=[];opts.cssBefore=$.extend({},opts.original.cssBefore);opts.cssAfter=$.extend({},opts.original.cssAfter);opts.animIn=$.extend({},opts.original.animIn);opts.animOut=$.extend({},opts.original.animOut);opts.fxFn=null;$.each(opts.original.before,function(){opts.before.push(this);});$.each(opts.original.after,function(){opts.after.push(this);});var init=$.fn.cycle.transitions[fx];if($.isFunction(init)){init(opts.$cont,$(opts.elements),opts);}};function go(els,opts,manual,fwd){if(manual&&opts.busy&&opts.manualTrump){debug("manualTrump in go(), stopping active transition");$(els).stop(true,true);opts.busy=false;}if(opts.busy){debug("transition active, ignoring new tx request");return;}var p=opts.$cont[0],curr=els[opts.currSlide],next=els[opts.nextSlide];if(p.cycleStop!=opts.stopCount||p.cycleTimeout===0&&!manual){return;}if(!manual&&!p.cyclePause&&!opts.bounce&&((opts.autostop&&(--opts.countdown<=0))||(opts.nowrap&&!opts.random&&opts.nextSlide<opts.currSlide))){if(opts.end){opts.end(opts);}return;}var changed=false;if((manual||!p.cyclePause)&&(opts.nextSlide!=opts.currSlide)){changed=true;var fx=opts.fx;curr.cycleH=curr.cycleH||$(curr).height();curr.cycleW=curr.cycleW||$(curr).width();next.cycleH=next.cycleH||$(next).height();next.cycleW=next.cycleW||$(next).width();if(opts.multiFx){if(opts.lastFx==undefined||++opts.lastFx>=opts.fxs.length){opts.lastFx=0;}fx=opts.fxs[opts.lastFx];opts.currFx=fx;}if(opts.oneTimeFx){fx=opts.oneTimeFx;opts.oneTimeFx=null;}$.fn.cycle.resetState(opts,fx);if(opts.before.length){$.each(opts.before,function(i,o){if(p.cycleStop!=opts.stopCount){return;}o.apply(next,[curr,next,opts,fwd]);});}var after=function(){$.each(opts.after,function(i,o){if(p.cycleStop!=opts.stopCount){return;}o.apply(next,[curr,next,opts,fwd]);});};debug("tx firing; currSlide: "+opts.currSlide+"; nextSlide: "+opts.nextSlide);opts.busy=1;if(opts.fxFn){opts.fxFn(curr,next,opts,after,fwd,manual&&opts.fastOnEvent);}else{if($.isFunction($.fn.cycle[opts.fx])){$.fn.cycle[opts.fx](curr,next,opts,after,fwd,manual&&opts.fastOnEvent);}else{$.fn.cycle.custom(curr,next,opts,after,fwd,manual&&opts.fastOnEvent);}}}if(changed||opts.nextSlide==opts.currSlide){opts.lastSlide=opts.currSlide;if(opts.random){opts.currSlide=opts.nextSlide;if(++opts.randomIndex==els.length){opts.randomIndex=0;}opts.nextSlide=opts.randomMap[opts.randomIndex];if(opts.nextSlide==opts.currSlide){opts.nextSlide=(opts.currSlide==opts.slideCount-1)?0:opts.currSlide+1;}}else{if(opts.backwards){var roll=(opts.nextSlide-1)<0;if(roll&&opts.bounce){opts.backwards=!opts.backwards;opts.nextSlide=1;opts.currSlide=0;}else{opts.nextSlide=roll?(els.length-1):opts.nextSlide-1;opts.currSlide=roll?0:opts.nextSlide+1;}}else{var roll=(opts.nextSlide+1)==els.length;if(roll&&opts.bounce){opts.backwards=!opts.backwards;opts.nextSlide=els.length-2;opts.currSlide=els.length-1;}else{opts.nextSlide=roll?0:opts.nextSlide+1;opts.currSlide=roll?els.length-1:opts.nextSlide-1;}}}}if(changed&&opts.pager){opts.updateActivePagerLink(opts.pager,opts.currSlide,opts.activePagerClass);}var ms=0;if(opts.timeout&&!opts.continuous){ms=getTimeout(els[opts.currSlide],els[opts.nextSlide],opts,fwd);}else{if(opts.continuous&&p.cyclePause){ms=10;}}if(ms>0){p.cycleTimeout=setTimeout(function(){go(els,opts,0,(!opts.rev&&!opts.backwards));},ms);}}$.fn.cycle.updateActivePagerLink=function(pager,currSlide,clsName){$(pager).each(function(){$(this).children().removeClass(clsName).eq(currSlide).addClass(clsName);});};function getTimeout(curr,next,opts,fwd){if(opts.timeoutFn){var t=opts.timeoutFn.call(curr,curr,next,opts,fwd);while((t-opts.speed)<250){t+=opts.speed;}debug("calculated timeout: "+t+"; speed: "+opts.speed);if(t!==false){return t;}}return opts.timeout;}$.fn.cycle.next=function(opts){advance(opts,opts.rev?-1:1);};$.fn.cycle.prev=function(opts){advance(opts,opts.rev?1:-1);};function advance(opts,val){var els=opts.elements;var p=opts.$cont[0],timeout=p.cycleTimeout;if(timeout){clearTimeout(timeout);p.cycleTimeout=0;}if(opts.random&&val<0){opts.randomIndex--;if(--opts.randomIndex==-2){opts.randomIndex=els.length-2;}else{if(opts.randomIndex==-1){opts.randomIndex=els.length-1;}}opts.nextSlide=opts.randomMap[opts.randomIndex];}else{if(opts.random){opts.nextSlide=opts.randomMap[opts.randomIndex];}else{opts.nextSlide=opts.currSlide+val;if(opts.nextSlide<0){if(opts.nowrap){return false;}opts.nextSlide=els.length-1;}else{if(opts.nextSlide>=els.length){if(opts.nowrap){return false;}opts.nextSlide=0;}}}}var cb=opts.onPrevNextEvent||opts.prevNextClick;if($.isFunction(cb)){cb(val>0,opts.nextSlide,els[opts.nextSlide]);}go(els,opts,1,val>=0);return false;}function buildPager(els,opts){var $p=$(opts.pager);$.each(els,function(i,o){$.fn.cycle.createPagerAnchor(i,o,$p,els,opts);});opts.updateActivePagerLink(opts.pager,opts.startingSlide,opts.activePagerClass);}$.fn.cycle.createPagerAnchor=function(i,el,$p,els,opts){var a;if($.isFunction(opts.pagerAnchorBuilder)){a=opts.pagerAnchorBuilder(i,el);debug("pagerAnchorBuilder("+i+", el) returned: "+a);}else{a='<a href="#">'+(i+1)+"</a>";}if(!a){return;}var $a=$(a);if($a.parents("body").length===0){var arr=[];if($p.length>1){$p.each(function(){var $clone=$a.clone(true);$(this).append($clone);arr.push($clone[0]);});$a=$(arr);}else{$a.appendTo($p);}}opts.pagerAnchors=opts.pagerAnchors||[];opts.pagerAnchors.push($a);$a.bind(opts.pagerEvent,function(e){e.preventDefault();opts.nextSlide=i;var p=opts.$cont[0],timeout=p.cycleTimeout;if(timeout){clearTimeout(timeout);p.cycleTimeout=0;}var cb=opts.onPagerEvent||opts.pagerClick;if($.isFunction(cb)){cb(opts.nextSlide,els[opts.nextSlide]);}go(els,opts,1,opts.currSlide<i);});if(!/^click/.test(opts.pagerEvent)&&!opts.allowPagerClickBubble){$a.bind("click.cycle",function(){return false;});}if(opts.pauseOnPagerHover){$a.hover(function(){opts.$cont[0].cyclePause++;},function(){opts.$cont[0].cyclePause--;});}};$.fn.cycle.hopsFromLast=function(opts,fwd){var hops,l=opts.lastSlide,c=opts.currSlide;if(fwd){hops=c>l?c-l:opts.slideCount-l;}else{hops=c<l?l-c:l+opts.slideCount-c;}return hops;};function clearTypeFix($slides){debug("applying clearType background-color hack");function hex(s){s=parseInt(s).toString(16);return s.length<2?"0"+s:s;}function getBg(e){for(;e&&e.nodeName.toLowerCase()!="html";e=e.parentNode){var v=$.css(e,"background-color");if(v.indexOf("rgb")>=0){var rgb=v.match(/\d+/g);return"#"+hex(rgb[0])+hex(rgb[1])+hex(rgb[2]);}if(v&&v!="transparent"){return v;}}return"#ffffff";}$slides.each(function(){$(this).css("background-color",getBg(this));});}$.fn.cycle.commonReset=function(curr,next,opts,w,h,rev){$(opts.elements).not(curr).hide();opts.cssBefore.opacity=1;opts.cssBefore.display="block";if(w!==false&&next.cycleW>0){opts.cssBefore.width=next.cycleW;}if(h!==false&&next.cycleH>0){opts.cssBefore.height=next.cycleH;}opts.cssAfter=opts.cssAfter||{};opts.cssAfter.display="none";$(curr).css("zIndex",opts.slideCount+(rev===true?1:0));$(next).css("zIndex",opts.slideCount+(rev===true?0:1));};$.fn.cycle.custom=function(curr,next,opts,cb,fwd,speedOverride){var $l=$(curr),$n=$(next);var speedIn=opts.speedIn,speedOut=opts.speedOut,easeIn=opts.easeIn,easeOut=opts.easeOut;$n.css(opts.cssBefore);if(speedOverride){if(typeof speedOverride=="number"){speedIn=speedOut=speedOverride;}else{speedIn=speedOut=1;}easeIn=easeOut=null;}var fn=function(){$n.animate(opts.animIn,speedIn,easeIn,cb);};$l.animate(opts.animOut,speedOut,easeOut,function(){if(opts.cssAfter){$l.css(opts.cssAfter);}if(!opts.sync){fn();}});if(opts.sync){fn();}};$.fn.cycle.transitions={fade:function($cont,$slides,opts){$slides.not(":eq("+opts.currSlide+")").css("opacity",0);opts.before.push(function(curr,next,opts){$.fn.cycle.commonReset(curr,next,opts);opts.cssBefore.opacity=0;});opts.animIn={opacity:1};opts.animOut={opacity:0};opts.cssBefore={top:0,left:0};}};$.fn.cycle.ver=function(){return ver;};$.fn.cycle.defaults={fx:"fade",timeout:4000,timeoutFn:null,continuous:0,speed:1000,speedIn:null,speedOut:null,next:null,prev:null,onPrevNextEvent:null,prevNextEvent:"click.cycle",pager:null,onPagerEvent:null,pagerEvent:"click.cycle",allowPagerClickBubble:false,pagerAnchorBuilder:null,before:null,after:null,end:null,easing:null,easeIn:null,easeOut:null,shuffle:null,animIn:null,animOut:null,cssBefore:null,cssAfter:null,fxFn:null,height:"auto",startingSlide:0,sync:1,random:0,fit:0,containerResize:1,pause:0,pauseOnPagerHover:0,autostop:0,autostopCount:0,delay:0,slideExpr:null,cleartype:!$.support.opacity,cleartypeNoBg:false,nowrap:0,fastOnEvent:0,randomizeEffects:1,rev:0,manualTrump:true,requeueOnImageNotLoaded:true,requeueTimeout:250,activePagerClass:"activeSlide",updateActivePagerLink:null,backwards:false};})(jQuery);
//(function($){$.fn.cycle.transitions.none=function($cont,$slides,opts){opts.fxFn=function(curr,next,opts,after){$(next).show();$(curr).hide();after();};};$.fn.cycle.transitions.scrollUp=function($cont,$slides,opts){$cont.css("overflow","hidden");opts.before.push($.fn.cycle.commonReset);var h=$cont.height();opts.cssBefore={top:h,left:0};opts.cssFirst={top:0};opts.animIn={top:0};opts.animOut={top:-h};};$.fn.cycle.transitions.scrollDown=function($cont,$slides,opts){$cont.css("overflow","hidden");opts.before.push($.fn.cycle.commonReset);var h=$cont.height();opts.cssFirst={top:0};opts.cssBefore={top:-h,left:0};opts.animIn={top:0};opts.animOut={top:h};};$.fn.cycle.transitions.scrollLeft=function($cont,$slides,opts){$cont.css("overflow","hidden");opts.before.push($.fn.cycle.commonReset);var w=$cont.width();opts.cssFirst={left:0};opts.cssBefore={left:w,top:0};opts.animIn={left:0};opts.animOut={left:0-w};};$.fn.cycle.transitions.scrollRight=function($cont,$slides,opts){$cont.css("overflow","hidden");opts.before.push($.fn.cycle.commonReset);var w=$cont.width();opts.cssFirst={left:0};opts.cssBefore={left:-w,top:0};opts.animIn={left:0};opts.animOut={left:w};};$.fn.cycle.transitions.scrollHorz=function($cont,$slides,opts){$cont.css("overflow","hidden").width();opts.before.push(function(curr,next,opts,fwd){$.fn.cycle.commonReset(curr,next,opts);opts.cssBefore.left=fwd?(next.cycleW-1):(1-next.cycleW);opts.animOut.left=fwd?-curr.cycleW:curr.cycleW;});opts.cssFirst={left:0};opts.cssBefore={top:0};opts.animIn={left:0};opts.animOut={top:0};};$.fn.cycle.transitions.scrollVert=function($cont,$slides,opts){$cont.css("overflow","hidden");opts.before.push(function(curr,next,opts,fwd){$.fn.cycle.commonReset(curr,next,opts);opts.cssBefore.top=fwd?(1-next.cycleH):(next.cycleH-1);opts.animOut.top=fwd?curr.cycleH:-curr.cycleH;});opts.cssFirst={top:0};opts.cssBefore={left:0};opts.animIn={top:0};opts.animOut={left:0};};$.fn.cycle.transitions.slideX=function($cont,$slides,opts){opts.before.push(function(curr,next,opts){$(opts.elements).not(curr).hide();$.fn.cycle.commonReset(curr,next,opts,false,true);opts.animIn.width=next.cycleW;});opts.cssBefore={left:0,top:0,width:0};opts.animIn={width:"show"};opts.animOut={width:0};};$.fn.cycle.transitions.slideY=function($cont,$slides,opts){opts.before.push(function(curr,next,opts){$(opts.elements).not(curr).hide();$.fn.cycle.commonReset(curr,next,opts,true,false);opts.animIn.height=next.cycleH;});opts.cssBefore={left:0,top:0,height:0};opts.animIn={height:"show"};opts.animOut={height:0};};$.fn.cycle.transitions.shuffle=function($cont,$slides,opts){var i,w=$cont.css("overflow","visible").width();$slides.css({left:0,top:0});opts.before.push(function(curr,next,opts){$.fn.cycle.commonReset(curr,next,opts,true,true,true);});if(!opts.speedAdjusted){opts.speed=opts.speed/2;opts.speedAdjusted=true;}opts.random=0;opts.shuffle=opts.shuffle||{left:-w,top:15};opts.els=[];for(i=0;i<$slides.length;i++){opts.els.push($slides[i]);}for(i=0;i<opts.currSlide;i++){opts.els.push(opts.els.shift());}opts.fxFn=function(curr,next,opts,cb,fwd){var $el=fwd?$(curr):$(next);$(next).css(opts.cssBefore);var count=opts.slideCount;$el.animate(opts.shuffle,opts.speedIn,opts.easeIn,function(){var hops=$.fn.cycle.hopsFromLast(opts,fwd);for(var k=0;k<hops;k++){fwd?opts.els.push(opts.els.shift()):opts.els.unshift(opts.els.pop());}if(fwd){for(var i=0,len=opts.els.length;i<len;i++){$(opts.els[i]).css("z-index",len-i+count);}}else{var z=$(curr).css("z-index");$el.css("z-index",parseInt(z)+1+count);}$el.animate({left:0,top:0},opts.speedOut,opts.easeOut,function(){$(fwd?this:curr).hide();if(cb){cb();}});});};opts.cssBefore={display:"block",opacity:1,top:0,left:0};};$.fn.cycle.transitions.turnUp=function($cont,$slides,opts){opts.before.push(function(curr,next,opts){$.fn.cycle.commonReset(curr,next,opts,true,false);opts.cssBefore.top=next.cycleH;opts.animIn.height=next.cycleH;});opts.cssFirst={top:0};opts.cssBefore={left:0,height:0};opts.animIn={top:0};opts.animOut={height:0};};$.fn.cycle.transitions.turnDown=function($cont,$slides,opts){opts.before.push(function(curr,next,opts){$.fn.cycle.commonReset(curr,next,opts,true,false);opts.animIn.height=next.cycleH;opts.animOut.top=curr.cycleH;});opts.cssFirst={top:0};opts.cssBefore={left:0,top:0,height:0};opts.animOut={height:0};};$.fn.cycle.transitions.turnLeft=function($cont,$slides,opts){opts.before.push(function(curr,next,opts){$.fn.cycle.commonReset(curr,next,opts,false,true);opts.cssBefore.left=next.cycleW;opts.animIn.width=next.cycleW;});opts.cssBefore={top:0,width:0};opts.animIn={left:0};opts.animOut={width:0};};$.fn.cycle.transitions.turnRight=function($cont,$slides,opts){opts.before.push(function(curr,next,opts){$.fn.cycle.commonReset(curr,next,opts,false,true);opts.animIn.width=next.cycleW;opts.animOut.left=curr.cycleW;});opts.cssBefore={top:0,left:0,width:0};opts.animIn={left:0};opts.animOut={width:0};};$.fn.cycle.transitions.zoom=function($cont,$slides,opts){opts.before.push(function(curr,next,opts){$.fn.cycle.commonReset(curr,next,opts,false,false,true);opts.cssBefore.top=next.cycleH/2;opts.cssBefore.left=next.cycleW/2;opts.animIn={top:0,left:0,width:next.cycleW,height:next.cycleH};opts.animOut={width:0,height:0,top:curr.cycleH/2,left:curr.cycleW/2};});opts.cssFirst={top:0,left:0};opts.cssBefore={width:0,height:0};};$.fn.cycle.transitions.fadeZoom=function($cont,$slides,opts){opts.before.push(function(curr,next,opts){$.fn.cycle.commonReset(curr,next,opts,false,false);opts.cssBefore.left=next.cycleW/2;opts.cssBefore.top=next.cycleH/2;opts.animIn={top:0,left:0,width:next.cycleW,height:next.cycleH};});opts.cssBefore={width:0,height:0};opts.animOut={opacity:0};};$.fn.cycle.transitions.blindX=function($cont,$slides,opts){var w=$cont.css("overflow","hidden").width();opts.before.push(function(curr,next,opts){$.fn.cycle.commonReset(curr,next,opts);opts.animIn.width=next.cycleW;opts.animOut.left=curr.cycleW;});opts.cssBefore={left:w,top:0};opts.animIn={left:0};opts.animOut={left:w};};$.fn.cycle.transitions.blindY=function($cont,$slides,opts){var h=$cont.css("overflow","hidden").height();opts.before.push(function(curr,next,opts){$.fn.cycle.commonReset(curr,next,opts);opts.animIn.height=next.cycleH;opts.animOut.top=curr.cycleH;});opts.cssBefore={top:h,left:0};opts.animIn={top:0};opts.animOut={top:h};};$.fn.cycle.transitions.blindZ=function($cont,$slides,opts){var h=$cont.css("overflow","hidden").height();var w=$cont.width();opts.before.push(function(curr,next,opts){$.fn.cycle.commonReset(curr,next,opts);opts.animIn.height=next.cycleH;opts.animOut.top=curr.cycleH;});opts.cssBefore={top:h,left:w};opts.animIn={top:0,left:0};opts.animOut={top:h,left:w};};$.fn.cycle.transitions.growX=function($cont,$slides,opts){opts.before.push(function(curr,next,opts){$.fn.cycle.commonReset(curr,next,opts,false,true);opts.cssBefore.left=this.cycleW/2;opts.animIn={left:0,width:this.cycleW};opts.animOut={left:0};});opts.cssBefore={width:0,top:0};};$.fn.cycle.transitions.growY=function($cont,$slides,opts){opts.before.push(function(curr,next,opts){$.fn.cycle.commonReset(curr,next,opts,true,false);opts.cssBefore.top=this.cycleH/2;opts.animIn={top:0,height:this.cycleH};opts.animOut={top:0};});opts.cssBefore={height:0,left:0};};$.fn.cycle.transitions.curtainX=function($cont,$slides,opts){opts.before.push(function(curr,next,opts){$.fn.cycle.commonReset(curr,next,opts,false,true,true);opts.cssBefore.left=next.cycleW/2;opts.animIn={left:0,width:this.cycleW};opts.animOut={left:curr.cycleW/2,width:0};});opts.cssBefore={top:0,width:0};};$.fn.cycle.transitions.curtainY=function($cont,$slides,opts){opts.before.push(function(curr,next,opts){$.fn.cycle.commonReset(curr,next,opts,true,false,true);opts.cssBefore.top=next.cycleH/2;opts.animIn={top:0,height:next.cycleH};opts.animOut={top:curr.cycleH/2,height:0};});opts.cssBefore={left:0,height:0};};$.fn.cycle.transitions.cover=function($cont,$slides,opts){var d=opts.direction||"left";var w=$cont.css("overflow","hidden").width();var h=$cont.height();opts.before.push(function(curr,next,opts){$.fn.cycle.commonReset(curr,next,opts);if(d=="right"){opts.cssBefore.left=-w;}else{if(d=="up"){opts.cssBefore.top=h;}else{if(d=="down"){opts.cssBefore.top=-h;}else{opts.cssBefore.left=w;}}}});opts.animIn={left:0,top:0};opts.animOut={opacity:1};opts.cssBefore={top:0,left:0};};$.fn.cycle.transitions.uncover=function($cont,$slides,opts){var d=opts.direction||"left";var w=$cont.css("overflow","hidden").width();var h=$cont.height();opts.before.push(function(curr,next,opts){$.fn.cycle.commonReset(curr,next,opts,true,true,true);if(d=="right"){opts.animOut.left=w;}else{if(d=="up"){opts.animOut.top=-h;}else{if(d=="down"){opts.animOut.top=h;}else{opts.animOut.left=-w;}}}});opts.animIn={left:0,top:0};opts.animOut={opacity:1};opts.cssBefore={top:0,left:0};};$.fn.cycle.transitions.toss=function($cont,$slides,opts){var w=$cont.css("overflow","visible").width();var h=$cont.height();opts.before.push(function(curr,next,opts){$.fn.cycle.commonReset(curr,next,opts,true,true,true);if(!opts.animOut.left&&!opts.animOut.top){opts.animOut={left:w*2,top:-h/2,opacity:0};}else{opts.animOut.opacity=0;}});opts.cssBefore={left:0,top:0};opts.animIn={left:0};};$.fn.cycle.transitions.wipe=function($cont,$slides,opts){var w=$cont.css("overflow","hidden").width();var h=$cont.height();opts.cssBefore=opts.cssBefore||{};var clip;if(opts.clip){if(/l2r/.test(opts.clip)){clip="rect(0px 0px "+h+"px 0px)";}else{if(/r2l/.test(opts.clip)){clip="rect(0px "+w+"px "+h+"px "+w+"px)";}else{if(/t2b/.test(opts.clip)){clip="rect(0px "+w+"px 0px 0px)";}else{if(/b2t/.test(opts.clip)){clip="rect("+h+"px "+w+"px "+h+"px 0px)";}else{if(/zoom/.test(opts.clip)){var top=parseInt(h/2);var left=parseInt(w/2);clip="rect("+top+"px "+left+"px "+top+"px "+left+"px)";}}}}}}opts.cssBefore.clip=opts.cssBefore.clip||clip||"rect(0px 0px 0px 0px)";var d=opts.cssBefore.clip.match(/(\d+)/g);var t=parseInt(d[0]),r=parseInt(d[1]),b=parseInt(d[2]),l=parseInt(d[3]);opts.before.push(function(curr,next,opts){if(curr==next){return;}var $curr=$(curr),$next=$(next);$.fn.cycle.commonReset(curr,next,opts,true,true,false);opts.cssAfter.display="block";var step=1,count=parseInt((opts.speedIn/13))-1;(function f(){var tt=t?t-parseInt(step*(t/count)):0;var ll=l?l-parseInt(step*(l/count)):0;var bb=b<h?b+parseInt(step*((h-b)/count||1)):h;var rr=r<w?r+parseInt(step*((w-r)/count||1)):w;$next.css({clip:"rect("+tt+"px "+rr+"px "+bb+"px "+ll+"px)"});(step++<=count)?setTimeout(f,13):$curr.css("display","none");})();});opts.cssBefore={display:"block",opacity:1,top:0,left:0};opts.animIn={left:0};opts.animOut={left:0};};})(jQuery);
//(function($){$.fn.jCarouselLite=function(o){o=$.extend({btnPrev:null,btnNext:null,btnGo:null,mouseWheel:false,auto:null,speed:200,easing:null,vertical:false,circular:true,visible:4,start:0,scroll:1,beforeStart:null,afterEnd:null},o||{});return this.each(function(){var b=false,animCss=o.vertical?"top":"left",sizeCss=o.vertical?"height":"width";var c=$(this),ul=$("ul",c),tLi=$("li",ul),tl=tLi.size(),v=o.visible;if(o.circular){ul.prepend(tLi.slice(tl-v-1+1).clone()).append(tLi.slice(0,v).clone());o.start+=v}var f=$("li",ul),itemLength=f.size(),curr=o.start;c.css("visibility","visible");f.css({overflow:"hidden",float:o.vertical?"none":"left"});ul.css({margin:"0",padding:"0",position:"relative","list-style-type":"none","z-index":"1"});c.css({overflow:"hidden",position:"relative","z-index":"2",left:"0px"});var g=o.vertical?height(f):width(f);var h=g*itemLength;var j=g*v;f.css({width:f.width(),height:f.height()});ul.css(sizeCss,h+"px").css(animCss,-(curr*g));c.css(sizeCss,j+"px");if(o.btnPrev)$(o.btnPrev).click(function(){return go(curr-o.scroll)});if(o.btnNext)$(o.btnNext).click(function(){return go(curr+o.scroll)});if(o.btnGo)$.each(o.btnGo,function(i,a){$(a).click(function(){return go(o.circular?o.visible+i:i)})});if(o.mouseWheel&&c.mousewheel)c.mousewheel(function(e,d){return d>0?go(curr-o.scroll):go(curr+o.scroll)});if(o.auto)setInterval(function(){go(curr+o.scroll)},o.auto+o.speed);function vis(){return f.slice(curr).slice(0,v)};function go(a){if(!b){if(o.beforeStart)o.beforeStart.call(this,vis());if(o.circular){if(a<=o.start-v-1){ul.css(animCss,-((itemLength-(v*2))*g)+"px");curr=a==o.start-v-1?itemLength-(v*2)-1:itemLength-(v*2)-o.scroll}else if(a>=itemLength-v+1){ul.css(animCss,-((v)*g)+"px");curr=a==itemLength-v+1?v+1:v+o.scroll}else curr=a}else{if(a<0||a>itemLength-v)return;else curr=a}b=true;ul.animate(animCss=="left"?{left:-(curr*g)}:{top:-(curr*g)},o.speed,o.easing,function(){if(o.afterEnd)o.afterEnd.call(this,vis());b=false});if(!o.circular){$(o.btnPrev+","+o.btnNext).removeClass("disabled");$((curr-o.scroll<0&&o.btnPrev)||(curr+o.scroll>itemLength-v&&o.btnNext)||[]).addClass("disabled")}}return false}})};function css(a,b){return parseInt($.css(a[0],b))||0};function width(a){return a[0].offsetWidth+css(a,'marginLeft')+css(a,'marginRight')};function height(a){return a[0].offsetHeight+css(a,'marginTop')+css(a,'marginBottom')}})(jQuery);

