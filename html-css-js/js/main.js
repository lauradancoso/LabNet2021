// Cuando carga el documento
jQuery(document).ready(function () {
  "use strict";
  $("#reset").click(() => askForResetForm());
  showOrHideElements($(".InvalidFeedback"), false, $(".ValidFeedback"), false);
  $("form").on("input", (e) => validateFullName(e));
  $("form").submit((e) => submitForm(e));
});

let submitValid = false;

const askForResetForm = () => {
  $("#InputName").focus();
  Swal.fire({
    title: "Estas seguro?",
    text: "Se borrarán los campos",
    icon: "warning",
    showCancelButton: true,
    confirmButtonColor: "#3085d6",
    cancelButtonColor: "#d33",
    confirmButtonText: "Sí, borrar!",
  }).then((result) => {
    if (result.isConfirmed) {
      showOrHideElements(
        $(".InvalidFeedback"),
        false,
        $(".ValidFeedback"),
        false
      );

      resetForm();
    }
  });
};
const resetForm = () => {
  $("form input:text").val("");
  $("form input[type='number']").prop("value", "");
  $("form input:radio").prop("checked", false);
};

const validateFullName = (e) => {
  let inputName = $("#InputName").val().trim();
  let inputLastName = $("#InputLastname").val().trim();

  let divNameValid = $("#DivName .ValidFeedback");
  let divNameInvalid = $("#DivName .InvalidFeedback");
  let divLastNameValid = $("#DivLastName .ValidFeedback");
  let divLastNameInvalid = $("#DivLastName .InvalidFeedback");

  let re = /^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]{2,}$/u;
  let fullNameisValid = re.test(inputName) && re.test(inputLastName);

  showOrHideElements($(".InvalidFeedback"), false, $(".ValidFeedback"), false);

  re.test(inputName)
    ? showOrHideElements(divNameInvalid, false, divNameValid, true)
    : showOrHideElements(divNameInvalid, true, divNameValid, false);

  re.test(inputLastName)
    ? showOrHideElements(divLastNameInvalid, false, divLastNameValid, true)
    : showOrHideElements(divLastNameInvalid, true, divLastNameValid, false);

  if (fullNameisValid)
    showOrHideElements(
      $(".InvalidFeedback"),
      false,
      $(".ValidFeedback"),
      false
    );
  submitValid = fullNameisValid;
};
const submitForm = (e) => {
  e.preventDefault();
  if (submitValid ? success() : error());
};
const showOrHideElements = (
  firstElement,
  firstShow,
  secondElement,
  secondShow
) => {
  firstShow ? firstElement.show() : firstElement.hide();
  secondShow ? secondElement.show() : secondElement.hide();
};
const error = () =>
  Swal.fire({
    icon: "error",
    title: "Error",
    text: "Verifique que la información esté correcta",
  });
const success = () => {
  $("#InputName").focus();
  Swal.fire({
    title: "Formulario listo para enviar!",
    icon: "success",
    timer: 1500,
    showCloseButton: true,
  }).then(() => resetForm());
};
