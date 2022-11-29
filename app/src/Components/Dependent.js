import React from 'react';
import AddDependentModal from './Modals/AddDependentModal';
import DeleteModal from "./Modals/DeleteModal";
import { relationshipFormat } from '../Utilities/Constants';
import { dependentsUrl, fetchDelete, fetchPut } from "../Utilities/ApiService";

class Dependent extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            editOpen: false,
            deleteOpen: false,
            firstName: this.props.firstName || '',
            lastName: this.props.lastName || '',
            dateOfBirth: this.props.dateOfBirth || '',
            relationship: this.props.relationship || 0,
        };

    };

    openEditModal = () => {
        this.setState({
         editOpen: true
        })
     }
 
    handleCloseEditModal = (reply) => {
        if(reply){
            fetchPut(`${dependentsUrl}/${this.props.id}`, reply)
            .then((response) => {
                this.setState({
                    firstName: response.data.firstName,
                    lastName: response.data.lastName,
                    dateOfBirth: response.data.dateOfBirth,
                    relationship: response.data.relationship
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

    render() {
    return (
        <tr>
            <th scope="row">{this.props.id}</th>
            <td>{this.state.lastName}</td>
            <td>{this.state.firstName}</td>
            <td>{this.state.dateOfBirth}</td>
            <td>{relationshipFormat(this.state.relationship)}</td>
            <td>
                <AddDependentModal
                data={this.props}
                editMode={true}
                IsModalOpen={this.state.editOpen}
                onCloseModal={this.handleCloseEditModal}
                />
                  <button type="button" className="btn btn-primary" onClick={this.openEditModal}>Edit</button>
                <DeleteModal
                data={this.props}
                employeeId={this.props.employeeId}
                IsModalOpen={this.state.deleteOpen}
                onCloseModal={this.handleCloseDeleteModal}
                />
                  <button type="button" className="btn btn-warn" onClick={this.openDeleteModal}>Delete</button>
            </td>
        </tr>
    );
    }
};

export default Dependent;