// Cuando carga el documento
jQuery(document).ready(function () {
  "use strict";
  $("#reset").click(() => resetForm());
  $(".InvalidFeedback").hide();
  $(".ValidFeedback").hide();
  $("form").on("input", (e) => validateFullName(e));
  $("form").submit((e) => submitForm(e));
});

let submitValid = false;
const resetForm = () => {
  $("form input:text").val("");
  $("form input[type='number']").prop("value", "");
  $("form input:radio").prop("checked", false);
};
const validateFullName = (e) => {
  let inputName = $("#InputName").val().trim();
  let inputLastName = $("#InputLastname").val().trim();
  let re = /^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]{2,}$/u;
  let isValid = re.test(inputName) && re.test(inputLastName);

  $(".InvalidFeedback").hide();
  $(".ValidFeedback").hide();
  if (re.test(inputName)) {
    $("#DivName .InvalidFeedback").hide();
    $("#DivName .ValidFeedback").show();
  } else {
    $("#DivName .InvalidFeedback").show();
    $("#DivName .ValidFeedback").hide();
  }
  if (re.test(inputLastName)) {
    $("#DivLastName .InvalidFeedback").hide();
    $("#DivLastName .ValidFeedback").show();
  } else {
    $("#DivLastName .InvalidFeedback").show();
    $("#DivLastName .ValidFeedback").hide();
  }
  if (isValid) {
    $(".InvalidFeedback").hide();
    $(".ValidFeedback").hide();
    submitValid = true;
  }
};
const submitForm = (e) => {
  e.preventDefault();
  if (submitValid) {
    alert("Formulario enviado");
  } else {
    alert("Verifique la información");
  }
};
