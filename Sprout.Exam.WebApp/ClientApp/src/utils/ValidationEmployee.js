



export function validateField(obj, fieldName, value)
{

    debugger;
  let state = obj.state;
 
  

  switch (fieldName) {
    case 'fullname': 
      let fullnameValid =  value.length > 0;
      state.formErrors.fullname = fullnameValid ? '' : 'Full Name is a required field';
      state.fullnameValid = fullnameValid;
      //state.formErrors = fieldValidationErrors;
      //this.setState({fullnameValid: fullnameValid,formErrors:fieldValidationErrors})
      break;
    case 'birthdate':
      let birthdateValid = value.length > 0;
      state.formErrors.birthdate = birthdateValid ? '' : 'Birth Date is a required field'
      state.birthdateValid = birthdateValid;
      //state.formErrors = fieldValidationErrors;
      //this.setState({birthdateValid: birthdateValid,formErrors:fieldValidationErrors})

      break;
    case 'typeId':
      let typeIdValid = value > 0;
      state.formErrors.typeId = typeIdValid ? '' : 'Employee Type is a required field'
      state.typeIdValid = typeIdValid;
      
      break;
    case 'tin':
      let tinValid = value.length > 0;
      state.formErrors.tin = tinValid ? '' : 'TIN is a required field'
      state.tinValid = tinValid;
      break;
  
    default:
      break;


  }

   obj.setState(state);

}

export function validateForm (obj){

    debugger;
    let state =obj.state;
    state.formValid = obj.state.fullnameValid && obj.state.birthdateValid && obj.state.tinValid && obj.state.typeIdValid;
    //this.setState(state);
    return state;

  }

export function errorClass(error) {

    return( error === undefined || error.length === 0 ? '' : 'has-error');
}

export function validateFields(obj)
{
  debugger;
  validateField(obj, 'fullname', obj.state.fullname || '');
  validateField(obj,'birthdate', obj.state.birthdate || '');
  validateField(obj,'tin', obj.state.tin || '');
  validateField(obj,'typeId', obj.state.typeId || 0);
  validateForm(obj);

}

