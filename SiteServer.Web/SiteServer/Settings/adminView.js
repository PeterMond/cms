﻿var $url = '/pages/settings/adminView';
var $pageTypeAdmin = 'admin';
var $pageTypeUser = 'user';

var data = {
  pageLoad: false,
  pageAlert: null,
  pageType: utils.getQueryString('pageType'),
  userId: parseInt(utils.getQueryString('userId') || '0'),
  userName: utils.getQueryString('userName'),
  returnUrl: utils.getQueryString('returnUrl'),
  administrator: null,
  level: null,
  isSuperAdmin: null,
  siteNames: null,
  isOrdinaryAdmin: null,
  roleNames: null
};

var methods = {
  getConfig: function () {
    var $this = this;

    $api.get($url, {
      params: {
        userId: this.userId,
        userName: this.userName
      }
    }).then(function (response) {
      var res = response.data;

      $this.administrator = res.administrator;
      $this.level = res.level;
      $this.isSuperAdmin = res.isSuperAdmin;
      $this.siteNames = res.siteNames;
      $this.isOrdinaryAdmin = res.isOrdinaryAdmin;
      $this.roleNames = res.roleNames;
    }).catch(function (error) {
      utils.error($this, error);
    }).then(function () {
      $this.pageLoad = true;
    });
  },

  btnReturnClick: function () {
    location.href = 'admin.cshtml';
  }
};

new Vue({
  el: '#main',
  data: data,
  methods: methods,
  created: function () {
    this.getConfig();
  }
});