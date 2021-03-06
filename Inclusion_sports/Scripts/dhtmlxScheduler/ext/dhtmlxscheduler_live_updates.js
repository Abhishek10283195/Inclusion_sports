/*

@license
dhtmlxScheduler.Net v.4.0.3 Professional Evaluation

This software is covered by DHTMLX Evaluation License. Contact sales@dhtmlx.com to get Commercial or Enterprise license. Usage without proper license is prohibited.

(c) XB Software Ltd.

*/
Scheduler.plugin(function(e){if("undefined"!=typeof dataProcessor){var t=dataProcessor.prototype.init;dataProcessor.prototype.init=function(){t.apply(this,arguments);var e=this;this.attachEvent("onAfterUpdate",function(t,a,i,n){var r;r=e.obj.exists(i)?e.obj.item(i):e.obj.exists(t)?e.obj.item(t):{},void 0!==r.$selected&&delete r.$selected,void 0!==r.$template&&delete r.$template,e.callEvent("onLocalUpdate",[{sid:t,tid:i,status:a,data:r}])})},dataProcessor.prototype.applyChanges=function(e){
var t=this,a=e.sid,i=e.tid,n=e.status,r=e.data;switch(t.obj.isSelected(a)&&(r.$selected=!0),n){case"updated":case"update":case"inserted":case"insert":t.obj.exists(a)?(t.obj.isLUEdit(r)===a&&t.obj.stopEditBefore(),t.ignore(function(){t.obj.update(a,r),a!==i&&t.obj.changeId(a,i)})):(r.id=i,t.ignore(function(){t.obj.add(r)}));break;case"deleted":case"delete":t.ignore(function(){var e=t.obj.exists(a);e&&(t.obj.setUserData(a,"!nativeeditor_status","true_deleted"),t.obj.stopEditBefore()),
t.obj.remove(a,r),e&&t.obj.isLUEdit(r)===a&&(t.obj.preventLUCollision(r),!1===t.obj.callEvent("onLiveUpdateCollision",[a,i,n,r])&&t.obj.stopEditAfter())})}}}void 0!==e&&(e.item=function(t){var a=this.getEvent(t);if(!a)return{};var i={};for(var n in a)i[n]=a[n];return i.start_date=e.date.date_to_str(e.config.api_date)(a.start_date),i.end_date=e.date.date_to_str(e.config.api_date)(a.end_date),i},e.update=function(t,a){var i=this.getEvent(t)
;for(var n in a)"start_date"!=n&&"end_date"!=n&&(i[n]=a[n]);var r=e.date.str_to_date(e.config.api_date);e.setEventStartDate(t,r(a.start_date)),e.setEventEndDate(t,r(a.end_date)),this.updateEvent(t),this.callEvent("onEventChanged",[t,i])},e.remove=function(t,a){if(this.exists(t)){var i=this.getEvent(t);if(this._get_rec_markers){i.rec_type&&this._roll_back_dates(i);var n=this._get_rec_markers(t);for(var r in n)n.hasOwnProperty(r)&&(t=n[r].id,this.getEvent(t)&&this.deleteEvent(t,!0))}
this.deleteEvent(t,!0)}else a&&a.event_pid&&e.add(a)},e.exists=function(e){return!!this.getEvent(e)},e.add=function(e){var t=this.addEvent(e.start_date,e.end_date,e.text,e.id,e);return this._is_modified_occurence&&this._is_modified_occurence(e)&&this.setCurrentView(),t},e.changeId=function(e,t){return this.changeEventId(e,t)},e.stopEditBefore=function(){},e.stopEditAfter=function(){this.endLightbox(!1,this._lightbox)},e.preventLUCollision=function(e){this._new_event=this._lightbox_id,
e.id=this._lightbox_id,this._events[this._lightbox_id]=e},e.isLUEdit=function(e){return this._lightbox_id?this._lightbox_id:null},e.isSelected=function(e){return!1})});