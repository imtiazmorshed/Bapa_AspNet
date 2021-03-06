﻿/*!
 * jQuery twitter bootstrap wizard plugin
 * Examples and documentation at: http://github.com/VinceG/twitter-bootstrap-wizard
 * version 1.0
 * Requires jQuery v1.3.2 or later
 * Supports Bootstrap 2.2.x, 2.3.x, 3.0
 * Dual licensed under the MIT and GPL licenses:
 * http://www.opensource.org/licenses/mit-license.php
 * http://www.gnu.org/licenses/gpl.html
 * Authors: Vadim Vincent Gabriel (http://vadimg.com), Jason Gill (www.gilluminate.com)
 */
(function (e) {
    var m = function (d, g) {
        d = e(d); var c = this, a = e.extend({}, e.fn.bootstrapWizard.defaults, g), f = null, b = null; this.rebindClick = function (b, a) { b.unbind("click", a).bind("click", a) }; this.fixNavigationButtons = function () {
            f.length || (b.find("a:first").tab("show"), f = b.find('li:has([data-toggle="tab"]):first')); e(a.previousSelector, d).toggleClass("disabled", c.firstIndex() >= c.currentIndex()); e(a.nextSelector, d).toggleClass("disabled", c.currentIndex() >= c.navigationLength()); c.rebindClick(e(a.nextSelector, d),
            c.next); c.rebindClick(e(a.previousSelector, d), c.previous); c.rebindClick(e(a.lastSelector, d), c.last); c.rebindClick(e(a.firstSelector, d), c.first); if (a.onTabShow && "function" === typeof a.onTabShow && !1 === a.onTabShow(f, b, c.currentIndex())) return !1
        }; this.next = function (h) { if (d.hasClass("last") || a.onNext && "function" === typeof a.onNext && !1 === a.onNext(f, b, c.nextIndex())) return !1; $index = c.nextIndex(); $index > c.navigationLength() || b.find('li:has([data-toggle="tab"]):eq(' + $index + ") a").tab("show") }; this.previous =
        function (h) { if (d.hasClass("first") || a.onPrevious && "function" === typeof a.onPrevious && !1 === a.onPrevious(f, b, c.previousIndex())) return !1; $index = c.previousIndex(); 0 > $index || b.find('li:has([data-toggle="tab"]):eq(' + $index + ") a").tab("show") }; this.first = function (h) { if (a.onFirst && "function" === typeof a.onFirst && !1 === a.onFirst(f, b, c.firstIndex()) || d.hasClass("disabled")) return !1; b.find('li:has([data-toggle="tab"]):eq(0) a').tab("show") }; this.last = function (h) {
            if (a.onLast && "function" === typeof a.onLast && !1 ===
            a.onLast(f, b, c.lastIndex()) || d.hasClass("disabled")) return !1; b.find('li:has([data-toggle="tab"]):eq(' + c.navigationLength() + ") a").tab("show")
        }; this.currentIndex = function () { return b.find('li:has([data-toggle="tab"])').index(f) }; this.firstIndex = function () { return 0 }; this.lastIndex = function () { return c.navigationLength() }; this.getIndex = function (a) { return b.find('li:has([data-toggle="tab"])').index(a) }; this.nextIndex = function () { return b.find('li:has([data-toggle="tab"])').index(f) + 1 }; this.previousIndex =
        function () { return b.find('li:has([data-toggle="tab"])').index(f) - 1 }; this.navigationLength = function () { return b.find('li:has([data-toggle="tab"])').length - 1 }; this.activeTab = function () { return f }; this.nextTab = function () { return b.find('li:has([data-toggle="tab"]):eq(' + (c.currentIndex() + 1) + ")").length ? b.find('li:has([data-toggle="tab"]):eq(' + (c.currentIndex() + 1) + ")") : null }; this.previousTab = function () { return 0 >= c.currentIndex() ? null : b.find('li:has([data-toggle="tab"]):eq(' + parseInt(c.currentIndex() - 1) + ")") };
        this.show = function (b) { return d.find('li:has([data-toggle="tab"]):eq(' + b + ") a").tab("show") }; this.disable = function (a) { b.find('li:has([data-toggle="tab"]):eq(' + a + ")").addClass("disabled") }; this.enable = function (a) { b.find('li:has([data-toggle="tab"]):eq(' + a + ")").removeClass("disabled") }; this.hide = function (a) { b.find('li:has([data-toggle="tab"]):eq(' + a + ")").hide() }; this.display = function (a) { b.find('li:has([data-toggle="tab"]):eq(' + a + ")").show() }; this.remove = function (a) {
            var c = "undefined" != typeof a[1] ? a[1] :
            !1; a = b.find('li:has([data-toggle="tab"]):eq(' + a[0] + ")"); c && (c = a.find("a").attr("href"), e(c).remove()); a.remove()
        }; var k = function (d) { d = b.find('li:has([data-toggle="tab"])').index(e(d.currentTarget).parent('li:has([data-toggle="tab"])')); if (a.onTabClick && "function" === typeof a.onTabClick && !1 === a.onTabClick(f, b, c.currentIndex(), d)) return !1 }, l = function (d) {
            $element = e(d.target).parent(); d = b.find('li:has([data-toggle="tab"])').index($element); if ($element.hasClass("disabled") || a.onTabChange && "function" ===
            typeof a.onTabChange && !1 === a.onTabChange(f, b, c.currentIndex(), d)) return !1; f = $element; c.fixNavigationButtons()
        }; this.resetWizard = function () { e('a[data-toggle="tab"]', b).off("click", k); e('a[data-toggle="tab"]', b).off("shown shown.bs.tab", l); b = d.find("ul:first", d); f = b.find('li:has([data-toggle="tab"]).active', d); e('a[data-toggle="tab"]', b).on("click", k); e('a[data-toggle="tab"]', b).on("shown shown.bs.tab", l); c.fixNavigationButtons() }; b = d.find("ul:first", d); f = b.find('li:has([data-toggle="tab"]).active',
        d); b.hasClass(a.tabClass) || b.addClass(a.tabClass); if (a.onInit && "function" === typeof a.onInit) a.onInit(f, b, 0); if (a.onShow && "function" === typeof a.onShow) a.onShow(f, b, c.nextIndex()); e('a[data-toggle="tab"]', b).on("click", k); e('a[data-toggle="tab"]', b).on("shown shown.bs.tab", l); this.fixNavigationButtons()
    }; e.fn.bootstrapWizard = function (d) {
        if ("string" == typeof d) { var g = Array.prototype.slice.call(arguments, 1); 1 === g.length && g.toString(); return this.data("bootstrapWizard")[d](g) } return this.each(function (c) {
            c =
            e(this); if (!c.data("bootstrapWizard")) { var a = new m(c, d); c.data("bootstrapWizard", a) }
        })
    }; e.fn.bootstrapWizard.defaults = { tabClass: "nav nav-pills", nextSelector: ".wizard li.next", previousSelector: ".wizard li.previous", firstSelector: ".wizard li.first", lastSelector: ".wizard li.last", onShow: null, onInit: null, onNext: null, onPrevious: null, onLast: null, onFirst: null, onTabChange: null, onTabClick: null, onTabShow: null }
})(jQuery);