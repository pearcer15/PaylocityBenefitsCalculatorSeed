import React from "react";
import { currencyFormat } from "../Utilities/Constants";
import { employeesUrl, fetchGet, fetchPut } from "../Utilities/ApiService";
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
            firstName: this.props.firstName || '',
            lastName: this.props.lastName || '',
            salary: this.props.salary || 0,
            dependents: this.props.dependents || [],
            dateOfBirth: this.props.dateOfBirth.split("T")[0],
        };
  
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

    handleCloseEditModal = (reply) => {
        if(reply){
            fetchPut(`${employeesUrl}/${this.props.id}`, reply)
            .then((response) => {
                this.setState({
                    firstName: response.data.firstName,
                    lastName: response.data.lastName,
                    salary: response.data.salary
                })
            })
        }
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
            this.props.deleted(this.props.id);
        }
    }

    handleDependentsChanged = (dependentArray) => {
        this.setState({
            dependents: dependentArray
        })
    }
    
    render(){
    return (
        <tr>
            <th scope="row">{this.props.id}</th>
            <td>{this.state.lastName}</td>
            <td>{this.state.firstName}</td>
            <td>{this.state.dateOfBirth}</td>
            <td>
                {currencyFormat(this.state.salary)}
                <PaycheckModal
                data={this.state.paycheck}
                IsModalOpen={this.state.paycheckOpen}
                onCloseModal={this.handleClosePaycheckModal}
                />
                <button type="button" className="btn btn-primary" onClick={this.openPaycheckModal}>View Paystub</button>
            </td>
            <td>{this.state.dependents?.length || 0}</td>
            <td>
                <AddEmployeeModal
                data={this.props}
                editMode={true}
                IsModalOpen={this.state.editOpen}
                onCloseModal={this.handleCloseEditModal}
                dependentsChanged={this.handleDependentsChanged}
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