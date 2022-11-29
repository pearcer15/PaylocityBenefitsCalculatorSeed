import React from "react";
import { currencyFormat } from "../Utilities/Constants";
import { employeesUrl, fetchDelete, fetchGet } from "../Utilities/ApiService";
import AddEmployeeModal from "./Modals/AddEmployeeModal";
import DeleteModal from "./Modals/DeleteModal";
import PaycheckModal from "./Modals/PaycheckModal";

class Employee extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            editOpen: false,
            deleteOpen: false,
            paycheckOpen: false,
            paycheck: [],
        };
        this.firstName = this.props.firstName || '';
        this.lastName = this.props.lastName || '';
        this.salary = this.props.salary || 0;
  
    }

    openPaycheckModal = () => {
        fetchGet(`${employeesUrl}/${this.props.id}/Paystub`)
        .then((response) => {
            if (response.success) {
                this.setState({
                    paycheck: response.data,
                    paycheckOpen: true
                })
            }
        })
            
     }
 
     handleClosePaycheckModal = () => {
         this.setState({
            paycheckOpen: false
         })
     } 

    openEditModal = () => {
       this.setState({
        editOpen: true
       })
    }

    handleCloseEditModal = () => {
        this.setState({
            editOpen: false
        })
    }

    openDeleteModal = () => {
        this.setState({
            deleteOpen: true
        })
    }

    handleCloseDeleteModal = (completeDelete) => {
        this.setState({
            deleteOpen: false
        })
        if(completeDelete){
            fetchDelete(`${employeesUrl}/${this.props.id}`);
        }
    }
    
    render(){
    return (
        <tr>
            <th scope="row">{this.props.id}</th>
            <td>{this.lastName}</td>
            <td>{this.firstName}</td>
            <td>{this.props.dateOfBirth}</td>
            <td>
                {currencyFormat(this.salary)}
                <PaycheckModal
                data={this.state.paycheck}
                IsModalOpen={this.state.paycheckOpen}
                onCloseModal={this.handleClosePaycheckModal}
                />
                <button type="button" className="btn btn-primary" onClick={this.openPaycheckModal}>View Paystub</button>
            </td>
            <td>{this.props.dependents?.length || 0}</td>
            <td>
                <AddEmployeeModal
                data={this.props}
                editMode={true}
                IsModalOpen={this.state.editOpen}
                onCloseModal={this.handleCloseEditModal}
                />
                  <button type="button" className="btn btn-primary" onClick={this.openEditModal}>Edit</button>
                <DeleteModal
                data={this.props}
                IsModalOpen={this.state.deleteOpen}
                onCloseModal={this.handleCloseDeleteModal}
                />
                  <button type="button" className="btn btn-warn" onClick={this.openDeleteModal}>Delete</button>
            </td>
        </tr>
    );
    }
};

export default Employee;