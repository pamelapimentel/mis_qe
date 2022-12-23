<template>
  <div class="row">
    <div class="col-sm-6">
      <input v-model="Id" type="hidden" name="Id">
      <div class="alert-container"></div>
      <div class="form-group">
          <label>Saludo</label>
          <input v-model="Salutation" type="text" class="form-control" name="Salutation">
          <span data-key="Salutation" class="form-validation-failed"></span>
      </div>
      <div class="form-group">
          <label>Primer Nombre</label>
          <input v-model="FirstName" type="text" class="form-control" name="FirstName">
          <span data-key="FirstName" class="form-validation-failed"></span>
      </div>
      <div class="form-group">
          <label>Segundo Nombre</label>
          <input v-model="SecondName" type="text" class="form-control" name="SecondName">
          <span data-key="SecondName" class="form-validation-failed"></span>
      </div>
      <div class="form-group">
          <label>Apellido Paterno</label>
          <input v-model="FatherLastName" type="text" class="form-control" name="FatherLastName">
          <span data-key="FatherLastName" class="form-validation-failed"></span>
      </div>
      <div class="form-group">
          <label>Apellido Materno</label>
          <input v-model="MotherLastName" type="text" class="form-control" name="MotherLastName">
      </div>
    </div>
    
    <div class="col-sm-6">
      <div class="form-group">
          <label>Celular</label>
          <input v-model="PhoneMobile" type="text" class="form-control" name="PhoneMobile">
          <span data-key="PhoneMobile" class="form-validation-failed"></span>
      </div>
      <div class="form-group">
          <label>Cargo</label>
          <input v-model="JobTitle" type="text" class="form-control" name="JobTitle">
          <span data-key="JobTitle" class="form-validation-failed"></span>
      </div>
      <div class="form-group">
          <label>Email</label>
          <input v-model="Email" type="text" class="form-control" name="Email">
          <span data-key="Email" class="form-validation-failed"></span>
      </div>
      <div class="form-group">
          <label>Cuenta</label>
          <select id="pais" class="form-control">
            <option>Peru</option>
            <option>Peru</option>
            <option>Peru</option>
            <option>Peru</option>
          </select>
      </div>
    </div>
  </div>
</template>

<script>
import icon from './global.icon.vue'
export default {
  components: {
    icon
  },
  data() {
    return {
      Id: 0,
      Salutation: '',
      FirstName: '',
      SecondName: '',
      FatherLastName: '',
      MotherLastName: '',
      PhoneMobile: '',
      JobTitle: '',
      Email: ''
    }
  },
  name: 'contacts',
  props: {
    url: {
      type: String,
      required: true
    }
  },
  mounted() {
    var self = this;
    this.$parent.$on('contactSelectID', function(v) {
      self.Id = v;
    })
  },
  watch: {
    Id(newValue, oldValue) {
      if(newValue > 0) {
        this.getContact(newValue);
      } else {
        this.newRecord();
      }
    }
  },
  methods: {
    getContact(Id) {
      var self = this;
      $.post(self.url, { id: Id }, function(r){ 
        self.FirstName = r.FirstName;
        self.SecondName = r.SecondName;
        self.FatherLastName = r.FatherLastName;
        self.MotherLastName = r.MotherLastName;
        self.PhoneMobile = r.PhoneMobile;
        self.JobTitle = r.JobTitle;
        self.Email = r.Email;
        self.Id   = Id;
      }, 'json')
    },
    newRecord() {
      var self = this;
      self.FirstName = '';
      self.SecondName = '';
      self.FatherLastName = '';
      self.MotherLastName = '';
      self.PhoneMobile = '';
      self.JobTitle = '';
      self.Email = '';
      self.Id   =  0;
    }
  }
}
</script>