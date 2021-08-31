///////////////////////////////JavaScript Ajax My Library//////////////////////////////////////////


//Using
//var pageUrl = window.location.pathname;
//function ChangeSomething(Id) {
//    ListAsenkronShort((sayfaUrlAdi + "/ListAsenkronShort"), '{Id:"' + Id + '"}', function (data) {
//        try {
//            if (data.Id == 0) {
//                throw data.d.Aciklama;
//            }
//            else {
//                console.log("Success");
//            }
//        } catch (e) {
//            alert(e);
//        }
//    });
//}
function Listele(adres, data, callback) {
    $.ajax({
        type: "POST",
        url: adres,
        data: data,
        contentType: "application/json; charset=utf-8",
        dataType: "JSON",
        success: function (data) {
            //console.log("1");
            try {
                //console.log("2");
                if (data.d.Id == 0) {
                    //console.log("3");
                    throw (data.d.Aciklama);
                    //Hatalıysa
                }
                else {
                    callback(data.d);
                }
            }
            catch (e) {
                //console.log("5");
                alert(e);
            }
            finally {
                //console.log("6");
                $("#loader").hide();
            }
        },
        error: function (result) {
            //console.log("7");
            alert(ErrorState(result.status));
        },
        beforeSend: function () {
            //$("#loader").show();
        },
        complete: function () {
            //$("#loader").hide();
        }
    });
}


//Using
//var pageUrl = window.location.pathname;
//TekSatirAsenkron((pageUrl + "/GetLastPerson"), '{tckimlikno:"' + $("#txtTcKimlikNo").val() + '"}', function (data) { $("#txtNameSurname").val(data.NameSurname); $("#txtGender").val(data.Gender); $("#txtBirthdate").val(data.Birthdate); });
function TekSatirAsenkron(adres, data, callback) {
    $.ajax({
        type: "POST",
        url: adres,
        data: data,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {
            try {
                if (data.d.Id == 0) {
                    throw data.d.Aciklama;
                }
                callback(data.d);
            } catch (e) {
                alert(e);
            }
        }, error: function (result) {
            alert(ErrorState(result.status));
        }
    });
}


//Using
//var pageUrl = window.location.pathname;
//function ChangeSomething(Id) {
//    ListAsenkronShort((sayfaUrlAdi + "/ListAsenkronShort"), '{Id:"' + Id + '"}', function (data) {
//        try {
//            if (data.Id == 0) {
//                throw data.d.Aciklama;
//            }
//            else {
//                console.log("Success");
//            }
//        } catch (e) {
//            alert(e);
//        }
//    });
//}

function ListeleAsenkron(adres, data, callback) {
    $.ajax({
        type: "POST",
        url: adres,
        data: data,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {
            callback(data.d);
        }, error: function (result) {
            alert(ErrorState(result.status));
        }
    });
}

function ErrorState(Code) {
    var errorMessage = "Error Code: " + Code + "<br>Error Message: ";
    if (Code == 505) {
        errorMessage += "HTTP Protokol versiyonu desteklenmiyor.";
    }
    else if (Code == 504) {
        errorMessage += "Gateway veya Proxy sunucusu, kaynağın bulunduğu sunucudan belirli bir zaman içinde cevap alamadı.";
    }
    else if (Code == 503) {
        errorMessage += "Sunucu şuanda kapalı ve ya erişilemiyor.";
    }
    else if (Code == 502) {
        errorMessage += "Gateway veya Proxy sunucusu, kaynağın bulunduğu sunucudan cevap alamıyor.";
    }
    else if (Code == 501) {
        errorMessage += "Sunucu istenilen isteği yerine getirecek şekilde yapılandırılmamıştır.";
    }
    else if (Code == 500) {
        errorMessage += "İstek Yapılan Adres Eksik Veya Zaman Aşımına Uğraşmış Olabilir. Buyüzden işleminiz Gerçekleştirilemedi.";
    }
    else if (Code == 414) {
        errorMessage += "URL fazla büyük.";
    }
    else if (Code == 413) {
        errorMessage += "İsteğin boyutu çok büyük olduğu için işlenemedi.";
    }
    else if (Code == 408) {
        errorMessage += "İstek zaman aşımına uğradı";
    }
    else if (Code == 404) {
        errorMessage += "İstek Yapılan Adres Bulunamadı için işleminiz Gerçekleştirilemedi.";
    }
    else if (Code == 403) {
        errorMessage += "Yasak Kaynağa Erişim Sağlanamadı.";
    }
    else if (Code == 401) {
        errorMessage += "Yetkisiz Erişim. İstek için kimlik doğrulaması gerekiyor.";
    }
    else if (Code == 400) {
        errorMessage += "İsteğin yapısının hatalı olduğunu belirtir.";
    }
    else if (Code == 200) {
        errorMessage += "OK. İstek ve Cevap Başarılıdır.";
    }
    else if (Code == 0) {
        errorMessage = "İstek Yapılan İşlem Yarıda Bırakıldı.";
    }
    return errorMessage;
}