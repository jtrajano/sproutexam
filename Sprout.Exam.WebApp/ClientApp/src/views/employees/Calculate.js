import React, { Component } from 'react';
import authService from '../../components/api-authorization/AuthorizeService';
import { errorClass } from '../../utils/ValidationEmployee';



export class EmployeeCalculate extends Component {
  static displayName = EmployeeCalculate.name;



  constructor(props) {
    super(props);
    this.state = { id: 0,fullName: '',birthdate: '',tin: '',typeId: 1,absentDays: 0,workedDays: 0,netIncome: 0,
    loading: true,loadingCalculate:false, AbsentDayError: '', WorkDayError: '' 
    
    };


  }

  componentDidMount() {
    this.getEmployee(this.props.match.params.id);
  }
  handleChange(event) {
    this.setState({ [event.target.name] : event.target.value},()=>{
      this.validateForm(event.target)

    });

  }

  validateForm({name, value}) {
   
    this.setState({netIncome : 0});
 
    
    switch (name) {
      case 'absentDays':
        this.setState({WorkDayError:''});
        this.setState({AbsentDayError:((!value || isNaN(value))   ? 'Numeric value is required!' : '' ) })
  
   

        
      case 'workedDays':
        this.setState({AbsentDayError:''});
        this.setState({WorkDayError:((!value || isNaN(value))   ? 'Numeric value is required!'  : '' ) })
     
    
      default:
        break;
    }
  

    
  }
  handleSubmit(e){
      e.preventDefault();
      if(this.state.typeId ===1)
        this.validateForm({name:'absentDays', value:this.state.absentDays})
      else
        this.validateForm({name:'workedDays', value:this.state.workedDays})

      if (!this.state.WorkDayError && !this.state.AbsentDayError)
        this.calculateSalary();
  }

  render() {

    let contents = this.state.loading
    ? <p><em>Loading...</em></p>
    : <div>
    <form>
<div className='form-row'>
<div className='form-group col-md-12'>
  <label>Full Name: <b>{this.state.fullName}</b></label>
</div>

</div>

<div className='form-row'>
<div className='form-group col-md-12'>
  <label >Birthdate: <b>{this.state.birthdate}</b></label>
</div>
</div>

<div className="form-row">
<div className='form-group col-md-12'>
  <label>TIN: <b>{this.state.tin}</b></label>
</div>
</div>

<div className="form-row">
<div className='form-group col-md-12'>
  <label>Employee Type: <b>{this.state.typeId === 1?"Regular": "Contractual"}</b></label>
</div>
</div>

{ this.state.typeId === 1?
 <div className="form-row">
     <div className='form-group col-md-12'><label>Salary: 20000 </label></div>
     <div className='form-group col-md-12'><label>Tax: 12% </label></div>
</div> : <div className="form-row">
<div className='form-group col-md-12'><label>Rate Per Day: 500 </label></div>
</div> }

<div className="form-row">

{ this.state.typeId === 1? 
<div className='form-group col-md-6'>
  <label htmlFor='inputAbsentDays4'>Absent Days: </label>
  <input type='text'   className={`form-control ${errorClass(this.state.AbsentDayError)}`}
  id='inputAbsentDays4' onChange={this.handleChange.bind(this)} value={this.state.absentDays} 
  name="absentDays" placeholder='Absent Days' />
  <span className='label-error'>{this.state.AbsentDayError}</span>
</div> :
<div className='form-group col-md-6'>
  <label htmlFor='inputWorkDays4'>Worked Days: </label>
  <input type='text' id='inputWorkDays4' 
  className={`form-control ${errorClass(this.state.WorkDayError)}`}
  onChange={this.handleChange.bind(this)} value={this.state.workedDays} 
  name="workedDays" placeholder='Worked Days' />
  <span className='label-error'>{this.state.WorkDayError} </span>
</div>
}
</div>

<div className="form-row">
<div className='form-group col-md-12'>
  <label>Net Income: <b>{this.state.netIncome}</b></label>
</div>
</div>

<button type="submit" onClick={this.handleSubmit.bind(this)} disabled={this.state.loadingCalculate} className="btn btn-primary mr-2">{this.state.loadingCalculate?"Loading...": "Calculate"}</button>
<button type="button" onClick={() => this.props.history.push("/employees/index")} className="btn btn-primary">Back</button>
</form>
</div>;


    return (
        <div>
        <h1 id="tabelLabel" >Employee Calculate Salary</h1>
        <br/>
        {contents}
      </div>
    );
  }

  async calculateSalary() {
    this.setState({ loadingCalculate: true });
    const token = await authService.getAccessToken();
    const requestOptions = {
        method: 'POST',
        headers: !token ? {} : { 'Authorization': `Bearer ${token}`,'Content-Type': 'application/json' },
        body: JSON.stringify({id: this.state.id,absentDays: this.state.absentDays,workedDays: this.state.workedDays})
    };
    const response = await fetch('api/employees/' + this.state.id + '/calculate',requestOptions);
    const data = await response.json();
    this.setState({ loadingCalculate: false,netIncome: data });
  }

  async getEmployee(id) {
    this.setState({ loading: true,loadingCalculate: false });
    const token = await authService.getAccessToken();
    const response = await fetch('api/employees/' + id, {
      headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
    });

    if(response.status === 200){
        const data = await response.json();
        this.setState({ 
          id: data.id,fullName: data.fullName,birthdate: data.birthdate,
          tin: data.tin,typeId: data.typeId, loading: false,
          loadingCalculate: false,
          AbsentDayError: '', 
          WorkDayError: '' });
    }
    else{
        alert("There was an error occured.");
        this.setState({ loading: false,loadingCalculate: false });
    }
  }
}
