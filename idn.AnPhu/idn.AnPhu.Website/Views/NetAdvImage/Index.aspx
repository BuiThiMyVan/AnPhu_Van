﻿<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Telerik.Web.Mvc.UI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Insert Image</title>
    <script type="text/javascript" src="/Scripts/tinymce/tiny_mce_popup.js"></script>
    <script type="text/javascript" src="/Scripts/tinymce/utils/mctabs.js"></script>
    <script type="text/javascript" src="/Scripts/tinymce/utils/form_utils.js"></script>
    <script type="text/javascript" src="/Scripts/tinymce/utils/validate.js"></script>
    <script type="text/javascript" src="/Scripts/tinymce/utils/editable_selects.js"></script>
    <script type="text/javascript" src="/Scripts/tinymce/plugins/netadvimage/js/jquery.js"></script>
    <script type="text/javascript" src="/Scripts/tinymce/plugins/netadvimage/js/jquery-ui.js"></script>
    <script type="text/javascript" src="/Scripts/tinymce/plugins/netadvimage/js/jquery.layout.js"></script>
    <script type="text/javascript" src="/Scripts/tinymce/plugins/netadvimage/js/dialog.js"></script>
    <script type="text/javascript" src="/Scripts/tinymce/plugins/netadvimage/js/fileuploader.js"></script>
    <link href="/Scripts/tinymce/plugins/netadvimage/css/dialog.css" rel="stylesheet" type="text/css" />
    <link href="/Scripts/tinymce/plugins/netadvimage/css/fileuploader.css" rel="stylesheet" type="text/css" />
    <%= Html.Telerik().StyleSheetRegistrar()
        .DefaultGroup(group => group.Add("2010.2.713/telerik.common.css")
                                    .Add("2010.2.713/telerik.default.css"))
    %>
</head>
<body id="netadvimage" style="display: none">
    <form id="mce" onsubmit="ImageDialog.insert();return false;" action="#">
    <div class="tabs">
        <ul>
            <li id="upload_tab" class="current"><span><a href="javascript:mcTabs.displayTab('upload_tab','upload_panel');" onmousedown="return false;">Upload</a></span></li>
            <li id="general_tab"><span><a href="javascript:mcTabs.displayTab('general_tab','general_panel');" onmousedown="return false;">General</a></span></li>
            <li id="advanced_tab"><span><a href="javascript:mcTabs.displayTab('advanced_tab','advanced_panel');" onmousedown="return false;">Advanced</a></span></li>
        </ul>
    </div>
    <div class="panel_wrapper">
        <div id="upload_panel" class="panel current">
            <div class="ui-layout-center">
                <ul id="img-list">
                </ul>
                <div id="img-upload">
                    <p>No images have been uploaded to this folder yet.</p>
                    <div id="upload">
                        &nbsp;</div>
                    <p>or, link to an <a class="img-ext" href="#">external image.</a></p>
                </div>
                <div id="prompt">
                    <img src="/Scripts/tinymce/plugins/netadvimage/img/arrow.gif" alt="<--" />
                    <p>Select a folder from the tree<br />
                        on the left</p>
                </div>
                <div id="mask">
                    &nbsp;</div>
                <div class="options img-options">
                    <ul>
                        <li><a href="#" title="Delete selected image" id="img-delete" class="t-drop">
                            <img src="/Scripts/tinymce/plugins/netadvimage/img/bin.gif" alt="Delete image" /></a></li>
                        <!--<li><a title="Rename selected image" href="#" id="img-edit" class="t-drop">
                            <img src="/Scripts/tinymce/plugins/netadvimage/img/pencil.gif" alt="Edit directory" /></a></li>-->
                        <li><a href="#" title="Add directory" class="img-upload">
                            <img src="/Scripts/tinymce/plugins/netadvimage/img/plus.gif" alt="Upload image" /></a></li>
                    </ul>
                </div>
            </div>
            <div class="ui-layout-west">
                <%= Html.Telerik().TreeView()
                        .Name("directory")
                        .DragAndDrop(settings =>
                            settings.DropTargets(".t-drop")
                        )
                        .ClientEvents(events =>
                        {
                            events.OnSelect("OnNodeSelect");
                            events.OnNodeDropped("OnNodeDropped");
                            events.OnNodeDrop("OnNodeDrop");
                            events.OnDataBinding("OnDataBinding");
                            events.OnCollapse("OnCollapse");
                            events.OnExpand("OnExpand");
                        })
                %>
                <div class="options dir-options">
                    <ul>
                        <li><a href="#" title="Delete selected directory" id="dir-delete" class="t-drop">
                            <img src="/Scripts/tinymce/plugins/netadvimage/img/bin.gif" alt="Delete directory" /></a></li>
                        <li><a href="#" title="Rename selected directory" id="dir-edit" class="t-drop">
                            <img src="/Scripts/tinymce/plugins/netadvimage/img/pencil.gif" alt="Edit directory" /></a></li>
                        <li><a href="#" title="Add directory" id="dir-add">
                            <img src="/Scripts/tinymce/plugins/netadvimage/img/plus.gif" alt="Add directory" /></a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div id="general_panel" class="panel">
            <fieldset>
                <legend>General</legend>
                <table class="properties">
                    <tr>
                        <td class="column1">
                            <label id="srclabel" for="src">
                                Image URL:</label>
                        </td>
                        <td colspan="2">
                            <table border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <input name="src" type="text" id="src" value="" class="mceFocus" onchange="ImageDialog.showPreviewImage(this.value);" />
                                    </td>
                                    <td id="srcbrowsercontainer">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="column1">
                            <label id="altlabel" for="alt">
                                Image (alt) description:</label>
                        </td>
                        <td colspan="2">
                            <input id="alt" name="alt" type="text" value="" />
                        </td>
                    </tr>
                    <tr>
                        <td class="column1">
                            <label id="titlelabel" for="title">
                                Tooltip:</label>
                        </td>
                        <td colspan="2">
                            <input id="title" name="title" type="text" value="" />
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset>
                <legend>Image Preview</legend>
                <div id="prev">
                </div>
            </fieldset>
        </div>
        <div id="advanced_panel" class="panel">
            <fieldset>
                <legend>Appearance</legend>
                <table border="0" cellpadding="4" cellspacing="0">
                    <tr>
                        <td class="column1">
                            <label id="alignlabel" for="align">
                                Alignment</label>
                        </td>
                        <td>
                            <select id="align" name="align" onchange="ImageDialog.updateStyle('align');ImageDialog.changeAppearance();">
                                <option value="">-- not set --</option>
                                <option value="baseline">Baseline</option>
                                <option value="top">Top</option>
                                <option value="middle">Middle</option>
                                <option value="bottom">Bottom</option>
                                <option value="text-top">Text top</option>
                                <option value="text-bottom">Text bottom</option>
                                <option value="left">Left</option>
                                <option value="right">Right</option>
                            </select>
                        </td>
                        <td rowspan="6" valign="top">
                            <div class="alignPreview">
                                <img id="alignSampleImg" src="/Scripts/tinymce/plugins/netadvimage/img/sample.gif" alt="Sample image" />
                                Lorem ipsum, Dolor sit amet, consectetuer adipiscing loreum ipsum edipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Loreum ipsum edipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="column1">
                            <label id="widthlabel" for="width">
                                Scale to:</label>
                        </td>
                        <td class="nowrap">
                            <input name="width" type="text" id="width" value="" size="5" maxlength="5" class="size" onchange="ImageDialog.changeHeight();" />
                            x
                            <input name="height" type="text" id="height" value="" size="5" maxlength="5" class="size" onchange="ImageDialog.changeWidth();" />
                            px
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <input id="constrain" type="checkbox" name="constrain" class="checkbox" />
                                    </td>
                                    <td>
                                        <label id="constrainlabel" for="constrain">
                                            Constrain proportions</label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="column1">
                            <label id="vspacelabel" for="vspace">
                                Vertical space:</label>
                        </td>
                        <td>
                            <input name="vspace" type="text" id="vspace" value="" size="3" maxlength="3" class="number" onchange="ImageDialog.updateStyle('vspace');ImageDialog.changeAppearance();" onblur="ImageDialog.updateStyle('vspace');ImageDialog.changeAppearance();" />
                        </td>
                    </tr>
                    <tr>
                        <td class="column1">
                            <label id="hspacelabel" for="hspace">
                                Horizontal space:</label>
                        </td>
                        <td>
                            <input name="hspace" type="text" id="hspace" value="" size="3" maxlength="3" class="number" onchange="ImageDialog.updateStyle('hspace');ImageDialog.changeAppearance();" onblur="ImageDialog.updateStyle('hspace');ImageDialog.changeAppearance();" />
                        </td>
                    </tr>
                    <tr>
                        <td class="column1">
                            <label id="borderlabel" for="border">
                                Border width:</label>
                        </td>
                        <td>
                            <input id="border" name="border" type="text" value="" size="3" maxlength="3" class="number" onchange="ImageDialog.updateStyle('border');ImageDialog.changeAppearance();" onblur="ImageDialog.updateStyle('border');ImageDialog.changeAppearance();" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="class_list">
                                CSS class:</label>
                        </td>
                        <td colspan="2">
                            <select id="class_list" name="class_list" class="mceEditableSelect">
                                <option value=""></option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td class="column1">
                            <label id="stylelabel" for="style">
                                Inline CSS styles:</label>
                        </td>
                        <td colspan="2">
                            <input id="style" name="style" type="text" value="" onchange="ImageDialog.changeAppearance();" />
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset>
                <legend>Miscellaneous</legend>
                <table border="0" cellpadding="4" cellspacing="0">
                    <tr>
                        <td class="column1">
                            <label id="idlabel" for="id">
                                Id:</label>
                        </td>
                        <td>
                            <input id="id" name="id" type="text" value="" />
                        </td>
                    </tr>
                    <tr>
                        <td class="column1">
                            <label id="dirlabel" for="dir">
                                Language direction</label>
                        </td>
                        <td>
                            <select id="dir" name="dir" onchange="ImageDialog.changeAppearance();">
                                <option value="">-- not set --</option>
                                <option value="ltr">Left to Right</option>
                                <option value="rtl">Right to Left</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td class="column1">
                            <label id="langlabel" for="lang">
                                Language code:</label>
                        </td>
                        <td>
                            <input id="lang" name="lang" type="text" value="" />
                        </td>
                    </tr>
                    <tr>
                        <td class="column1">
                            <label id="usemaplabel" for="usemap">
                                Image map:</label>
                        </td>
                        <td>
                            <input id="usemap" name="usemap" type="text" value="" />
                        </td>
                    </tr>
                    <tr>
                        <td class="column1">
                            <label id="longdesclabel" for="longdesc">
                                Long description link:</label>
                        </td>
                        <td>
                            <table border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <input id="longdesc" name="longdesc" type="text" value="" />
                                    </td>
                                    <td id="longdesccontainer">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </div>
    <div class="mceActionPanel">
        <input type="submit" id="insert" name="insert" value="Insert" />
        <input type="button" id="cancel" name="cancel" value="Cancel" onclick="tinyMCEPopup.close();" />
    </div>
    </form>
</body>
</html>
<%= Html.Telerik().ScriptRegistrar().DefaultGroup(group => group.DefaultPath("~/Scripts/2010.2.713")
                                    .Add("telerik.common.min.js")).jQuery(false) %>
<%--<%= Html.Telerik().ScriptRegistrar().DefaultGroup(
    group => group.Add("~/Scripts/2010.2.713/telerik.common.min.js")
                  ).jQuery(false) %>--%>
