import React from "react";
import { currencyFormat } from "../Utilities/Constants";
import AddEmployeeModal from "./Modals/EditEmployeeModal";

class Employee extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            editOpen: false,
        };
        this.firstName = this.props.firstName || '';
        this.lastName = this.props.lastName || '';
        this.salary = this.props.salary || 0;    
    }
    openEditModal = () => {
       this.setState({
        editOpen: true
       })
    }

    handleCloseModal(){
        this.setState({
            editOpen: false
        })
    }
    
    render(){
    return (
        <tr>
            <th scope="row">{this.props.id}</th>
            <td>{this.lastName}</td>
            <td>{this.firstName}</td>
            <td>{this.props.dateOfBirth}</td>
            <td>{currencyFormat(this.salary)}</td>
            <td>{this.props.dependents?.length || 0}</td>
            <td>
                <AddEmployeeModal
                data={this.props}
                IsModalOpen={this.state.editOpen}
                onCloseModal={this.handleCloseModal}
                />
                  <button onClick={this.openEditModal}>Edit</button>
            </td>
            <td><a href="#">Delete</a></td>
        </tr>
    );
    }
};

export default Employee;