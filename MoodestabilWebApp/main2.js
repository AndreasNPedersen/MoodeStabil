//const baseUrl = 'http://moodestabil.azurewebsites.net/api/subjects';
const baseUrl = "http://localhost:60475/api/Subjects";
let date1 = new Date().now;
Vue.createApp({
    data() {
        return {
            subjects:[],
            IdToGetBy: -1,
            updateData: { id: 0, subjectName: "", subjectMeetTime: date1},
            addData: { subjectName: "", subjectMeetTime: date1 },
            messageError: ""
        }
    },
    created() {
        this.getAllSubjects()
    },
    methods: {
        // Subject Methods
        async getAllSubjects() {
            this.get(baseUrl);
        },
        async getSubjectById(id) {
            const url = baseUrl + "/" + id
            this.get(url);
        },
        async addSubject() {
            try {
                response = await axios.post(baseUrl, this.addData)
                console.log(response)
                
                
            } catch (e) {
                alert(e.message)
            }
        },
        async updateSubject() {
            const url = baseUrl + "/" + this.updateData.id
            try {
                response = await axios.put(url, this.updateData)
                console.log(response)
            } catch (e) {
                alert(e.message)
            }
        },
        async DeleteSubject(id) {
            try {
                await axios.delete(baseUrl+"/"+id)
            } catch(ex){
                this.messageError = ex.message
            }
        },
        async get(url) {
            try {
                const response = await axios.get(url)
                
                this.subjects = await response.data
                
            } catch (e) {
                alert(e.message)
            }
        }
    }
}).mount("#app")