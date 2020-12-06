function Delete(a,b){swal({title:"Delete?",text:"Do you want to delete this row!",type:"warning",showCancelButton:!0,confirmButtonColor:"#DD6B55",confirmButtonText:"Yes!",cancelButtonText:"No!",closeOnConfirm:!1,closeOnCancel:!1},function(c){if(c){var d=b+"/"+a;$.ajax({type:"Delete",url:d,success:function(b){"Logon"==b?swal("Error!","Cookies is timeout please login again !","error"):1==b.State?(swal("Deleted!","Row was deleted.","success"),FadeOut(a,!0)):swal("Error!",b.ErrorMessage,"error")}})}else swal("Cancel","Row ID  :)","error",!1,"#DD6B55","Continue!")})}function Select(a){var b=a;$.ajax({url:b,type:"Get",success:function(a){"Logon"==a?ShowInformation("Cookies is timeout please login again !"):1==a.State?SuccessNotification():ErrorNotification(a.ErrorMessage+"Error : happend in row = "+a.RowID)},error:function(a,b,c){ErrorNotification(a.status+" "+c)}})}function AddOrUpdate(a,b,c){var d=a;$.ajax({type:c,url:d,data:b,contentType:"application/json; charset=utf-8",dataType:"json",success:function(a){"Logon"==a?ShowInformation("Cookies is timeout please login again !"):1==a.State?SuccessNotification():ErrorNotification(a.ErrorMessage+"Error : happend in row = "+a.RowID)},error:function(a,b,c){ErrorNotification(a.status+" "+c)}})}function AddCookie(a,b,c){$.cookie(a,b,{expires:c,path:"/"})}function GetCookie(a){return $.cookie(a)}function GetCookieInNumber(a){return $.cookie(a,Number)}function RemoveCookie(a){return $.removeCookie(a,{path:"/"})}function ConvertJsonDateString(a){var b=null;if(a){var c=/-?\d+/,d=c.exec(a),e=new Date(parseInt(d[0])),f=e.getMonth()+1,g=f>9?f:"0"+f,h=e.getDate(),i=h>9?h:"0"+h,j=e.getFullYear();b=g+"/"+i+"/"+j}return b}function isValidEmailAddress(a){var b=new RegExp(/^[+a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/i);return!b.test(a)}function CallClick(a){$("#"+a).trigger("click")}function Focus(a){$("#"+a).focus()}function Disable(a){$("#"+a).attr("disabled",!0)}function Enable(a){$("#"+a).attr("disabled",!1)}function IsChecked(a){var b=$("#"+a),c=b.is(":checked");return c}function SetImage(a,b){$("#"+a).attr("src",b)}function GetImage(a){return $("#"+a).attr("src")}function SubmitForm(a){$("#"+a).submit()}function IsEmpty(a){var b=$("#"+a).val();return!(b.length>0)}function FadeOut(a,b){b?$("#"+a).css("opacity",.3).delay(300).fadeOut("slow"):$("#"+a).css("opacity",.3).delay(300).fadeOut()}function FadeIn(a,b){b?$("#"+a).css("opacity",.3).delay(300).fadeIn("slow"):$("#"+a).css("opacity",.3).delay(300).fadeIn()}function FadeToggle(a,b){b?$("#"+a).css("opacity",.3).delay(300).fadeToggle("slow"):$("#"+a).css("opacity",.3).delay(300).fadeToggle()}function ChangeStyle(a,b,c){$("#"+a).removeClass(b).addClass(c)}function FindStyleValue(a,b){return $("#"+a).find("."+b).val()}function SetStyle(a,b){$("#"+a).$(this).css(b)}function Show(a){$("#"+a).show()}function Hide(a){$("#"+a).hide()}function SlideDown(a){$("#"+a).slideDown()}function SlideUp(a){$("#"+a).slideUp()}function SlideToggle(a){$("#"+a).slideToggle()}function Remove(a){$("#"+a).remove()}function Clear(a){$("#"+a).empty()}function GetValue(a){return $("#"+a).val()}function GetText(a){return $("#"+a).text()}function GetHtml(a){return $("#"+a).html()}function SetValue(a,b){$("#"+a).val(b)}function SetText(a,b){$("#"+a).text(b)}function SetHtml(a,b){$("#"+a).html(b)}function AppendContent(a,b){$("#"+a).append(b)}function AppendContent(a,b){$("#"+a).prepend(b)}function InsertAfter(a,b){$("#"+a).after(b)}function InsertBefore(a,b){$("#"+a).before(b)}function AddClass(a,b){$("#"+a).addClass(b)}function RemoveClass(a,b){$("#"+a).removeClass(b)}function ToogleClass(a,b){$("#"+a).toggleClass(b)}function ChangeColor(a,b){$("#"+a).css("background-color",b)}function Round(a){return Math.round(a)}function Floor(a){return Math.floor(a)}function Ceil(a){return Math.ceil(a)}function IndexOf(a,b){return a.indexOf(b)}function LastIndexOf(a,b){return a.lastIndexOf(b)}function Contain(a,b){return a.indexOf(b)>-1}function Slice(a,b,c){return a.Slice(b,c)}function Replace(a,b){return a.Replace(b)}function Upper(a){return a.toUpperCase()}function Lower(a){return a.toLowerCase()}function Concat(a,b){return a.concat(a,b)}function Split(a,b){return a.split(b)}function Fixed(a){return a.toFixed(2)}function ToInt(a){return parseInt(a)}function ToDouble(a){return parseFloat(a)}function ToString(a){return a.toString()}function IsArray(a){return a.constructor.toString().indexOf("Array")>-1}function IsDate(a){return a.constructor.toString().indexOf("Date")>-1}function Animate(a,b){$("#"+a).animate(b)}function Width(a){return $("#"+a).width()}function SetWidth(a,b){$("#"+a).width(b)}function WrapAll(a,b){$("#"+a).wrapAll(b)}function Wrap(a,b){$("#"+a).wrap(b)}function wrapInner(a,b){$("#"+a).wrapInner(b)}function ReplaceAll(a,b){$(b).replaceAll("#"+a)}function Each(a,b){$("#"+a).each(b)}function SetData(a,b,c){$("#"+a).data(b,c)}function GetData(a,b){return $("#"+a).attr(b)}function Bind(a,b){var c=document.getElementById(a);c.addEventListener("click",function(){b()})}function Blur(a,b){var c=document.getElementById(a);c.addEventListener("blur",function(){b()})}function Click(a,b){var c=document.getElementById(a);c.addEventListener("click",function(){b()})}function DbClick(a,b){var c=document.getElementById(a);c.addEventListener("dbclick",function(){b()})}function Focus(a,b){var c=document.getElementById(a);c.addEventListener("focus",function(){b()})}function FocusIn(a,b){var c=document.getElementById(a);c.addEventListener("focusin",function(){b()})}function FocusOut(a,b){var c=document.getElementById(a);c.addEventListener("focusout",function(){b()})}function Hover(a,b){var c=document.getElementById(a);c.addEventListener("hover",function(){b()})}function MouseDown(a,b){var c=document.getElementById(a);c.addEventListener("mousedown",function(){b()})}function MouseLeave(a,b){var c=document.getElementById(a);c.addEventListener("mouseleave",function(){b()})}function MouseEnter(a,b){var c=document.getElementById(a);c.addEventListener("mouseenter",function(){b()})}function MouseMove(a,b){var c=document.getElementById(a);c.addEventListener("mousemove",function(){b()})}function MouseOut(a,b){var c=document.getElementById(a);c.addEventListener("mouseout",function(){b()})}function MouseOver(a,b){var c=document.getElementById(a);c.addEventListener("mouseover",function(){b()})}function MouseUp(a,b){var c=document.getElementById(a);c.addEventListener("mouseup",function(){b()})}function KeyDown(a,b){var c=document.getElementById(a);c.addEventListener("keydown",function(){b()})}function KeyPress(a,b){var c=document.getElementById(a);c.addEventListener("keypress",function(){b()})}function KeyUp(a,b){var c=document.getElementById(a);c.addEventListener("keyup",function(){b()})}function Load(a,b){var c=document.getElementById(a);c.addEventListener("load",function(){b()})}function Select(a,b){var c=document.getElementById(a);c.addEventListener("select",function(){b()})}function Toggle(a,b){var c=document.getElementById(a);c.addEventListener("toggle",function(){b()})}function Trigger(a,b,c){var d=document.getElementById(a);d.addEventListener("click",function(){FunctionName(),$("#"+b).trigger(c)})}function UnBind(a){$("#"+a).unbind()}function GetMessages(){var a=GetData("Lang","data-Lang");return"ar"==a?messages_ar:messages_en}function BlockUI(){$.blockUI({css:{border:"none",padding:"15px",backgroundColor:"#000","-webkit-border-radius":"10px","-moz-border-radius":"10px",opacity:.5,color:"#fff"},message:"Please Wait .. "}),setTimeout($.unblockUI,1e3)}function ModalInfo(a,b){$.dialog({title:a,content:b})}function DeleteSwal(a,b,c){swal({title:messages[0],text:messages[1],type:"warning",showCancelButton:!0,confirmButtonColor:"#DD6B55",confirmButtonText:messages[2],cancelButtonText:messages[3],closeOnConfirm:!1,closeOnCancel:!1},function(d){if(d){var e="/"+b+"/"+c;$.ajax({type:"POST",traditional:!0,url:e,async:!1,data:{ID:a},dataType:"json",success:function(b){"Logon"==b?swal(messages[7],messages[4],"error"):1==b.State?(swal(messages[5],messages[6],"success"),FadeOut(a,!0)):swal(messages[7],b.ErrorMessage,"error")},error:function(a,b,c){swal(messages[3],messages[8],"error",!1,"#DD6B55","Continue!")}})}else swal(messages[3],messages[8],"error",!1,"#DD6B55","Continue!")})}function Delete(a,b,c){$.confirm({theme:"black",keyboardEnabled:!0,content:messages[13],confirmButton:messages[14],cancelButton:messages[15],animation:"rotateY",autoClose:"cancel|10000",confirm:function(){var d="/"+b+"/"+c,d="/"+b+"/"+c;$.ajax({type:"POST",traditional:!0,url:d,async:!1,data:{ID:a},dataType:"json",success:function(b){"Logon"==b?ErrorNotification(messages[7]+messages[4]):1==b.State?FadeOut(a,!0):ErrorNotification(messages[7]+b.ErrorMessage)},error:function(a,b,c){}})},cancel:function(){}})}function ExecuteLogout(a,b,c){var d="/"+b+"/"+c;return $.ajax({url:d,type:"POST",dataType:"json",traditional:!0,data:JSON.stringify(a),contentType:"application/json; charset=utf-8",success:function(a){return"Logon"==a?(ShowInformation(messages[4]),!1):(SuccessNotification(messages[9],messages[10]),!0)},error:function(a,b,c){return ErrorNotification(a.status+" "+c),!1}}),!0}function Execute(a,b,c){var d="/"+b+"/"+c;return $.ajax({url:d,type:"POST",dataType:"json",traditional:!0,data:JSON.stringify(a),contentType:"application/json; charset=utf-8",success:function(a){return"Logon"==a?(ShowInformation(messages[4]),!1):1==a.State?(SuccessNotification(messages[9],messages[10]),!0):(ErrorNotification(a.ErrorMessage),!1)},error:function(a,b,c){return ErrorNotification(a.status+" "+c),!1}}),!0}function ExecuteParameters(a,b,c){var d="/"+b+"/"+c;$.ajax({type:"POST",traditional:!0,url:d,async:!1,data:a,dataType:"json",success:function(a){"Logon"==a?SuccessNotification(messages[4]):1==a.State?SuccessNotification(messages[9],messages[10]):ErrorNotification(a.ErrorMessage+messages[11]+a.RowID)},error:function(a,b,c){ErrorNotification(ID,a.status+" "+c)}})}function ExecuteJsonAfterTime(a,b,c,d){var e=function(){Execute(a,b,c)};setTimeout(e,d)}function ExecutePaamsAfterTime(a,b,c,d){var e=function(){ExecuteParameters(a,b,c)};setTimeout(e,d)}function GoToPageAfterTime(a,b,c){window.setTimeout(function(){window.location.href="/"+a+"/"+b},c)}function GoToPage(a,b){location.href="/"+a+"/"+b}function ErrorNotification(a){function b(){return"stack_bar_top"==g?"100%":"stack_bar_bottom"==g?"70%":"290px"}var c={stack_top_right:{dir1:"down",dir2:"left",push:"top",spacing1:10,spacing2:10},stack_top_left:{dir1:"down",dir2:"right",push:"top",spacing1:10,spacing2:10},stack_bottom_left:{dir1:"right",dir2:"up",push:"top",spacing1:10,spacing2:10},stack_bottom_right:{dir1:"left",dir2:"up",push:"top",spacing1:10,spacing2:10},stack_bar_top:{dir1:"down",dir2:"right",push:"top",spacing1:0,spacing2:0},stack_bar_bottom:{dir1:"up",dir2:"right",spacing1:0,spacing2:0},stack_context:{dir1:"down",dir2:"left",context:$("#stack-context")}},d="danger",e=!0,f="1",g="stack_bar_top";g=g?g:"stack_top_right",f=f?f:"1",new PNotify({title:messages[7],text:a,shadow:e,opacity:f,addclass:g,type:d,stack:c[g],width:b(),delay:1400})}function SuccessNotification(){function a(){return"stack_bar_top"==f?"100%":"stack_bar_bottom"==f?"70%":"290px"}var b={stack_top_right:{dir1:"down",dir2:"left",push:"top",spacing1:10,spacing2:10},stack_top_left:{dir1:"down",dir2:"right",push:"top",spacing1:10,spacing2:10},stack_bottom_left:{dir1:"right",dir2:"up",push:"top",spacing1:10,spacing2:10},stack_bottom_right:{dir1:"left",dir2:"up",push:"top",spacing1:10,spacing2:10},stack_bar_top:{dir1:"down",dir2:"right",push:"top",spacing1:0,spacing2:0},stack_bar_bottom:{dir1:"up",dir2:"right",spacing1:0,spacing2:0},stack_context:{dir1:"down",dir2:"left",context:$("#stack-context")}},c="success",d=!0,e="1",f="stack_bar_top";f=f?f:"stack_top_right",e=e?e:"1",new PNotify({title:messages[9],text:messages[10],shadow:d,opacity:e,addclass:f,type:c,stack:b[f],width:a(),delay:1400})}function SuccessNotification(a){function b(){return"stack_bar_top"==g?"100%":"stack_bar_bottom"==g?"70%":"290px"}var c={stack_top_right:{dir1:"down",dir2:"left",push:"top",spacing1:10,spacing2:10},stack_top_left:{dir1:"down",dir2:"right",push:"top",spacing1:10,spacing2:10},stack_bottom_left:{dir1:"right",dir2:"up",push:"top",spacing1:10,spacing2:10},stack_bottom_right:{dir1:"left",dir2:"up",push:"top",spacing1:10,spacing2:10},stack_bar_top:{dir1:"down",dir2:"right",push:"top",spacing1:0,spacing2:0},stack_bar_bottom:{dir1:"up",dir2:"right",spacing1:0,spacing2:0},stack_context:{dir1:"down",dir2:"left",context:$("#stack-context")}},d="success",e=!0,f="1",g="stack_bar_top";g=g?g:"stack_top_right",f=f?f:"1",new PNotify({title:messages[9],text:a,shadow:e,opacity:f,addclass:g,type:d,stack:c[g],width:b(),delay:1400})}function ShowInformation(a){setTimeout(function(){var b=new NotificationFx({message:'<span class="icon icon-calendar"></span><p>'+a+".</p>",layout:"attached",effect:"bouncyflip",type:"notice",onClose:function(){}});b.show()},1200)}!function(a){"function"==typeof define&&define.amd?define(["jquery"],a):a("object"==typeof exports?require("jquery"):jQuery)}(function(a){function b(a){return h.raw?a:encodeURIComponent(a)}function c(a){return h.raw?a:decodeURIComponent(a)}function d(a){return b(h.json?JSON.stringify(a):String(a))}function e(a){0===a.indexOf('"')&&(a=a.slice(1,-1).replace(/\\"/g,'"').replace(/\\\\/g,"\\"));try{return a=decodeURIComponent(a.replace(g," ")),h.json?JSON.parse(a):a}catch(b){}}function f(b,c){var d=h.raw?b:e(b);return a.isFunction(c)?c(d):d}var g=/\+/g,h=a.cookie=function(e,g,i){if(void 0!==g&&!a.isFunction(g)){if(i=a.extend({},h.defaults,i),"number"==typeof i.expires){var j=i.expires,k=i.expires=new Date;k.setTime(+k+864e5*j)}return document.cookie=[b(e),"=",d(g),i.expires?"; expires="+i.expires.toUTCString():"",i.path?"; path="+i.path:"",i.domain?"; domain="+i.domain:"",i.secure?"; secure":""].join("")}for(var l=e?void 0:{},m=document.cookie?document.cookie.split("; "):[],n=0,o=m.length;o>n;n++){var p=m[n].split("="),q=c(p.shift()),r=p.join("=");if(e&&e===q){l=f(r,g);break}e||void 0===(r=f(r))||(l[q]=r)}return l};h.defaults={},a.removeCookie=function(b,c){return void 0===a.cookie(b)?!1:(a.cookie(b,"",a.extend({},c,{expires:-1})),!a.cookie(b))}}),BuildHTML=function(a,b,c){"string"!=typeof b&&(c=b,b=null);var d="<"+a;for(attr in c)c[attr]!==!1&&(d+=" "+attr+'="'+c[attr]+'"');return d+=b?">"+b+"</"+a+">":"/>"};var messages_en=["Information ?","Do you want to delete this row .!","OK!","Cancel!","Cookies is timeout please login again !","Deleted!","Your row was deleted.","Error!","Your row isn't deleted :)","Successfully .. ?","Successfully .. ? ","Error : happend in row = ",'Go <a href="/Account/Login">To login Page</a> now.',"Press ESC or ENTER to see it in action.","Yes i agree!","No never!"],messages_ar=["معلومة ؟","هل تريد خذف هذا السطر !","نعم","لا","الجلسه إنتهت يرجى إعاده تسجيل الدخول","الحذف","تم حذف السطر","خطأ","لم يتم حذف السطر","تمت العمليه بنجاح","تمت العمليه بنجاح","الخطأ حدث للسطر رقم",'==> <a href="/Account/Login">تسجيل الدخول</a>',"يمكنك استعمال زر الهروب أوأنتر هنا","نعم انا موافق","إبطال الامر"],messages=GetMessages();