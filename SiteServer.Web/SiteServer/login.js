var $url = '/pages/login';
var $urlLogin = '/v1/administrators/actions/login';
var $urlGetCaptcha = '/v1/captcha/LOGIN-CAPTCHA';
var $urlCheckCaptcha = '/v1/captcha/LOGIN-CAPTCHA/actions/check';

if (window.top != self) {
  window.top.location = self.location;
}

var data = utils.initData({
  pageSubmit: false,
  pageAlert: null,
  account: null,
  password: null,
  isAutoLogin: false,
  captcha: null,
  captchaUrl: null,
  productVersion: null,
  adminTitle: null
});

var methods = {
  load: function () {
    var $this = this;

    utils.loading($this, true);
    $api.get($url).then(function (response) {
      var res = response.data;

      if (res.value) {
        $this.productVersion = res.productVersion;
        $this.adminTitle = res.adminTitle;
        $this.reload();
      } else {
        location.href = res.redirectUrl;
      }
    }).catch(function (error) {
      utils.error($this, error);
    }).then(function () {
      utils.loading($this, false);
    });
  },

  reload: function () {
    this.captcha = '';
    this.pageSubmit = false;
    this.captchaUrl = apiUrl + $urlGetCaptcha + '?r=' + new Date().getTime();
  },

  checkCaptcha: function () {
    var $this = this;

    utils.loading($this, true);
    $api.post($urlCheckCaptcha, {
      captcha: $this.captcha
    }).then(function (response) {
      $this.login();
    }).catch(function (error) {
      $this.reload();
      utils.loading($this, false);
      utils.error($this, error);
    });
  },

  login: function () {
    var $this = this;

    utils.loading($this, true);
    $api.post($urlLogin, {
      account: $this.account,
      password: md5($this.password),
      isAutoLogin: $this.isAutoLogin
    }).then(function (response) {
      localStorage.setItem('sessionId', response.data.sessionId);
      if (response.data.isEnforcePasswordChange) {
        $this.redirectPassword();
      } else {
        $this.redirectMain();
      }
    }).catch(function (error) {
      utils.error($this, error);
    }).then(function () {
      $this.reload();
      utils.loading($this, false);
    });
  },

  redirectPassword: function () {
    location.href = 'settings/adminPassword.cshtml';
  },

  redirectMain: function () {
    location.href = 'main.cshtml';
  },

  btnLoginClick: function (e) {
    e.preventDefault();

    this.pageSubmit = true;
    this.pageAlert = null;
    if (!this.account || !this.password || !this.captcha) return;
    this.checkCaptcha();
  }
};

var $vue = new Vue({
  el: '#main',
  data: data,
  directives: {
    focus: {
      inserted: function (el) {
        el.focus()
      }
    }
  },
  methods: methods,
  created: function () {
    this.load();
  }
});
